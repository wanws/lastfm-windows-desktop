﻿using LastFM.ApiClient;
using LastFM.ApiClient.Models;
using LastFM.Common.Classes;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using Newtonsoft.Json;

namespace LastFM.Common.Factories
{
    public static class ScrobbleFactory
    {
        public enum OnlineState
        {
            Online,
            Offline
        }

        private static LastFMClient _lastFMClient = null;
        private static Timer _scrobbleTimer = null;
        private static int _scrobbleTimerSeconds = 0;

        private static bool _scrobblingActive = false;
        private static bool _isInitialized = false;

        private static NotificationThread _uiThread = null;

        public delegate void TrackStarted(MediaItem mediaItem);
        public delegate void TrackEnded(MediaItem mediaItem);

        public delegate void OnlineStatusUpdate(OnlineState currentState);

        public static OnlineStatusUpdate OnlineStatusUpdated { get; set; }

        public static int MinimumScrobbleSeconds { get; set;} = 30;

        public static List<IScrobbleSource> ScrobblePlugins { get; set; } = new List<IScrobbleSource>();

        public static bool ScrobblingEnabled
        {
            get
            {
                return _scrobblingActive;
            }

            set
            {
                _scrobblingActive = value;

                if(_scrobblingActive && _isInitialized)
                {
                    _scrobbleTimer.Start();

                    foreach (IScrobbleSource scrobbler in ScrobblePlugins)
                    {
                        if (Convert.ToBoolean(Core.Settings.ScrobblerStatus.FirstOrDefault(plugin => plugin.Identifier == scrobbler.SourceIdentifier)?.IsEnabled))
                        {
                            scrobbler.IsEnabled = true;
                        }
                    }
                }
                else if (_isInitialized)
                {
                    _scrobbleTimer.Stop();

                    foreach(IScrobbleSource plugin in ScrobblePlugins)
                    {
                        plugin.IsEnabled = false;
                    }
                }
            }
        }

        public static void Initialize(LastFMClient lastFMClient, NotificationThread uiThread)
        {
            _uiThread = uiThread;
            _lastFMClient = lastFMClient;

            // Get the plugins
            foreach(IScrobbleSource source in ScrobblePlugins)
            {
                source.InitializeSource(MinimumScrobbleSeconds, ScrobbleSource_OnTrackStarted, ScrobbleSource_OnTrackEnded);
            }

            _scrobbleTimer = new Timer(1000);
            _scrobbleTimer.Elapsed += ScrobbleTimer_Elapsed;

            _isInitialized = true;
        }

        private static void ScrobbleSource_OnTrackStarted(MediaItem mediaItem)
        {
            mediaItem.StartedPlaying = DateTime.Now;
            _lastFMClient.SendPlayStatusChanged(mediaItem, LastFMClient.PlayStatus.StartedListening);
        }

        private static void ScrobbleSource_OnTrackEnded(MediaItem mediaItem)
        {
            _lastFMClient.SendPlayStatusChanged(mediaItem, LastFMClient.PlayStatus.StoppedListening);
        }

        private static async void ScrobbleTimer_Elapsed(object sender, ElapsedEventArgs e)
        {
            _scrobbleTimer.Stop();

            if(_scrobblingActive)
            {
                _scrobbleTimerSeconds++;

                if (_scrobbleTimerSeconds >= MinimumScrobbleSeconds)
                {
                    _scrobbleTimerSeconds = 0;
                    await CheckScrobbleState();
                }
            }

            _uiThread?.SetStatus($"Next Scrobble check in {MinimumScrobbleSeconds - _scrobbleTimerSeconds} second(s)");

            if (_scrobblingActive)
            {
                _scrobbleTimer.Start();
            }
        }

        private static async Task CheckScrobbleState()
        {
            List<IScrobbleSource> sourcesToScrobbleFrom = null;

            if (_scrobblingActive)
            {
                _uiThread.SetStatus("Checking Scrobble State...");

                List<MediaItem> sourceMedia = new List<MediaItem>();

                sourceMedia = await LoadCachedScrobbles();

                foreach (IScrobbleSource source in ScrobblePlugins?.Where(plugin => plugin.IsEnabled).ToList())
                {
                    List<MediaItem> pluginMedia = source.MediaToScrobble;

                    sourceMedia.AddRange(pluginMedia);
                    source.ClearQueuedMedia();
                }

                if (await CanScrobble())
                {
                    if (sourceMedia != null && sourceMedia.Any())
                    {
                        _uiThread.SetStatus($"Scrobbling {sourceMedia.Count} item(s)....");

                        try
                        {
                            ScrobbleResponse scrobbleResult = await _lastFMClient.SendScrobbles(sourceMedia);
                            CacheFailedItems(scrobbleResult.Scrobbles.ScrobbleItems.ToList());
                        }
                        catch (Exception)
                        {
                            CacheOfflineItems(sourceMedia);
                        }
                    }
                    else
                    {
                        CacheOfflineItems(sourceMedia);
                    }
                }
            }

        }

        private async static Task<List<MediaItem>> LoadCachedScrobbles()
        {
            List<MediaItem> failedMedia = new List<MediaItem>();

            List<MediaItem> offlineScrobbleMedia = await LoadOfflineScrobbles();
            List<MediaItem> failedScrobbleMedia = await LoadFailedScrobbles();

            if(offlineScrobbleMedia != null  && offlineScrobbleMedia.Any())
            {
                failedMedia.AddRange(offlineScrobbleMedia);
            }

            if(failedScrobbleMedia != null && failedScrobbleMedia.Any())
            {
                failedMedia.AddRange(failedScrobbleMedia);
            }

            return failedMedia;
        }

        private static async Task<List<MediaItem>> LoadFailedScrobbles()
        {
            List<MediaItem> mediaItems = null;

            string loadingPattern = $"*{Core.FAILEDSCROBBLE_NOCONNECTION}";
            string[] availableFiles = Directory.GetFiles(Core.UserCachePath, loadingPattern);

            foreach (string availableFile in availableFiles)
            {
                try
                {
                    string serializedScrobbles = File.ReadAllText(availableFile);
                    File.Delete(availableFile);

                    List<Scrobble> failedScrobbles = JsonConvert.DeserializeObject<List<Scrobble>>(serializedScrobbles);

                    foreach(Scrobble failedScrobble in failedScrobbles)
                    {
                        MediaItem psuedoItem = new MediaItem()
                        {
                            AlbumName = failedScrobble.Album.CorrectedText,
                            ArtistName = failedScrobble.Artist.CorrectedText,
                            TrackName = failedScrobble.Track.CorrectedText
                        };

                        mediaItems.Add(psuedoItem);
                    }
                }
                catch (Exception ex)
                {
                    // The file couldn't be loaded... we probably should report this back somehow.
                    // ...but that's not part of the spec for this phase of the project!
                }
            }

            return mediaItems;

        }

        private static async Task<List<MediaItem>> LoadOfflineScrobbles()
        {
            List<MediaItem> mediaItems = null;

            string loadingPattern = $"*{Core.FAILEDSCROBBLE_NOCONNECTION}";
            string[] availableFiles = Directory.GetFiles(Core.UserCachePath, loadingPattern);

            foreach(string availableFile in availableFiles)
            {
                try
                {
                    string serializedScrobbles = File.ReadAllText(availableFile);
                    File.Delete(availableFile);

                    mediaItems = JsonConvert.DeserializeObject<List<MediaItem>>(serializedScrobbles);
                }
                catch (Exception ex)
                {
                    // The file couldn't be loaded... we probably should report this back somehow.
                    // ...but that's not part of the spec for this phase of the project!
                }
            }

            return mediaItems;
        }

        private static void CacheFailedItems(List<Scrobble> scrobbles)
        {
            if (scrobbles != null)
            {
                List<Scrobble> failedItems = scrobbles?.Where(item => item.IgnoredMessage.Code == ApiClient.Enums.ReasonCodes.IgnoredReason.ScrobbleLimitExceeded)?.ToList();

                if (failedItems.Any())
                {
                    string fileToWrite = $"{Core.UserCachePath}\\FailedScrobbles_{DateTime.Now:dd_MMM_yyyy}{Core.FAILEDSCROBBLE_LIMITEXCEEDEDFILENAMEEXTENSION}";
                    string dataToWrite = JsonConvert.SerializeObject(failedItems);

                    try
                    {
                        File.WriteAllText(fileToWrite, dataToWrite, Encoding.UTF8);
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
        }

        private static void CacheOfflineItems(List<MediaItem> scrobbles)
        {
            if (scrobbles != null && scrobbles.Any())
            {
                string fileToWrite = $"{Core.UserCachePath}\\OfflineScrobbles_{DateTime.Now:dd_MMM_yyyy}{Core.FAILEDSCROBBLE_NOCONNECTION}";
                string dataToWrite = JsonConvert.SerializeObject(scrobbles);

                try
                {
                    File.WriteAllText(fileToWrite, dataToWrite, Encoding.UTF8);
                }
                catch (Exception e)
                {
                }
            }
        }


        private static async Task<bool> CanScrobble()
        {
            bool canScrobble = false;

            try
            {
                var userInfo = await _lastFMClient.GetUserInfo(Core.Settings.Username);
                canScrobble = !string.IsNullOrEmpty(userInfo?.Name);
            }
            catch (Exception ex)
            {

            }

            OnlineStatusUpdated?.Invoke((canScrobble) ? OnlineState.Online : OnlineState.Offline);

            return canScrobble;
        }

        public static async void Dispose()
        {
            _scrobbleTimer?.Stop();
            _scrobbleTimer = null;

            // Get the unscrobbled media
            List<MediaItem> sourceMedia = new List<MediaItem>();

            sourceMedia = await LoadCachedScrobbles();

            foreach (IScrobbleSource plugin in ScrobblePlugins)
            {
                List<MediaItem> pluginMedia = plugin.MediaToScrobble;

                sourceMedia.AddRange(pluginMedia);
                plugin.ClearQueuedMedia();

                plugin.IsEnabled = false;
                plugin.Dispose();
            }

            CacheOfflineItems(sourceMedia);
        }

    }
}