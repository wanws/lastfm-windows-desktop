﻿using LastFM.Common.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace LastFM.Common.Static_Classes
{
    public static class VersionChecker
    {
        public class VersionState
        {
            public bool IsNewVersion { get; set; }
            public string Version { get; set; }
            public string Url { get; set; }
        }

        public static async Task<VersionState> CheckVersion(string versionURL)
        {
            byte[] numArray = await LoadPage(versionURL).ConfigureAwait(false);
            byte[] versionPageBytes = numArray;

            string versionPageSource = Encoding.UTF8.GetString(versionPageBytes);

            VersionState versionFromSource = await GetVersionFromSource(versionPageSource).ConfigureAwait(false);

            return versionFromSource;
        }

        private static async Task<byte[]> LoadPage(string versionURL)
        {
            byte[] numArray = await LoadPageAsync(versionURL).ConfigureAwait(false);
            return numArray;
        }

        private static async Task<byte[]> LoadPageAsync(string url)
        {
            MemoryStream content = new MemoryStream();
            try
            {
                HttpWebRequest webReq = (HttpWebRequest)WebRequest.Create(url);
                WebResponse response = webReq.GetResponse();
                try
                {
                    Stream responseStream = response.GetResponseStream();
                    try
                    {
                        responseStream.CopyTo((Stream)content);
                    }
                    finally
                    {
                        if (responseStream != null)
                        {
                            responseStream.Dispose();
                        }
                    }
                }
                finally
                {
                    if (response != null)
                    {
                        response.Dispose();
                    }
                }
            }
            catch (Exception ex)
            {
            }
            return content.ToArray();
        }

        internal static void CleanUpDownloads()
        {
            if (Directory.Exists(Core.UserDownloadsPath))
            {
                try
                {
                    Directory.Delete(Core.UserDownloadsPath, true);
                }
                catch (Exception ex)
                {
                    // Do nothing...
                }
            }
        }

        internal static async Task<VersionState> GetVersionFromSource(string pageSource)
        {
            // Load the page source in the Agility Pack so that we can parse the DOM effectively
            HtmlDocument updateDoc = new HtmlDocument();
            VersionState state = new VersionState() { IsNewVersion = false, Url = String.Empty, Version = string.Empty };

            updateDoc.LoadHtml(pageSource);

            // Find any 'H3' elements in the document
            var pageH3s = updateDoc.DocumentNode.Descendants("h3");

            if (pageH3s != null)
            {
                // The first one that has a 'Zip' file as its source, is our upgrade file
                var firstZipLink = pageH3s.Select(h3 => h3.Descendants("a").FirstOrDefault(a => a.Attributes["href"] != null && a.Attributes["href"].Value != null && a.Attributes["href"].Value.ToLower().Contains(".zip"))).FirstOrDefault(item => item != null);

                if (firstZipLink != null)
                {
                    List<string> linkText = firstZipLink.InnerText.Split(' ').ToList();
                    if (linkText.Count >= 3)
                    {
                        // Use the link text to get the version number
                        string webVersionInfo = linkText[1];

                        // Get the current version number (note the process DOESN'T take into account revisions...)
                        string appVersionInfo = ApplicationUtility.BuildVersion();

                        ApplicationUtility.VersionState currentState = ApplicationUtility.CompareVersions(appVersionInfo, webVersionInfo);

                        if (currentState == ApplicationUtility.VersionState.WebIsNewer)
                        {
                            state.IsNewVersion = true;
                            state.Version = webVersionInfo;
                            state.Url = firstZipLink.Attributes["href"].Value;
                        }
                    }
                }
            }

            updateDoc = null;

            return state;
        }

        internal static async Task DownloadUpdate(VersionChecker.VersionState downloadInfo, string downloadDirectory, DownloadProgressChangedEventHandler progressEventHandler, AsyncCompletedEventHandler downloadCompleted)
        {
            string downloadOSFilename = new Uri(downloadInfo.Url).PathAndQuery.Replace('/', Path.DirectorySeparatorChar);
            FileInfo downloadFileInfo = new FileInfo(downloadOSFilename);

            using (WebClient client = new WebClient())
            {
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(progressEventHandler);
                client.DownloadFileCompleted += new AsyncCompletedEventHandler(downloadCompleted);
                client.DownloadFileAsync(new Uri(downloadInfo.Url), $"{downloadDirectory}{downloadFileInfo.Name}", downloadInfo);
            }
        }
    }
}
