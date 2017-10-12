﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace LastFM.Common.Localization {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "15.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public class LocalizationStrings {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal LocalizationStrings() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("LastFM.Common.Localization.LocalizationStrings", typeof(LocalizationStrings).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        public static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The Desktop Scrobbler is already running..
        /// </summary>
        public static string Application_InstanceAlreadyRunning {
            get {
                return ResourceManager.GetString("Application_InstanceAlreadyRunning", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log In Required.
        /// </summary>
        public static string AuthenticationUi_AuthorizationRequired_WindowTitle {
            get {
                return ResourceManager.GetString("AuthenticationUi_AuthorizationRequired_WindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log In.
        /// </summary>
        public static string AuthenticationUi_AuthorizeButton {
            get {
                return ResourceManager.GetString("AuthenticationUi_AuthorizeButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Cancel.
        /// </summary>
        public static string AuthenticationUi_CancelButton {
            get {
                return ResourceManager.GetString("AuthenticationUi_CancelButton", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to There was an error logging in. Please try again..
        /// </summary>
        public static string AuthenticationUI_FailedToAuthorize_Message {
            get {
                return ResourceManager.GetString("AuthenticationUI_FailedToAuthorize_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to {0} Failed to Log In.
        /// </summary>
        public static string AuthenticationUi_FailedToAuthorize_MessageTitle {
            get {
                return ResourceManager.GetString("AuthenticationUi_FailedToAuthorize_MessageTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to To scrobble to Last.fm, you must log in.
        ///
        ///Click on &apos;Log In&apos; to open Last.fm, then click on &apos;Yes, allow access&apos; in the browser window that follows..
        /// </summary>
        public static string AuthenticationUi_InstructionsText {
            get {
                return ResourceManager.GetString("AuthenticationUi_InstructionsText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log In.
        /// </summary>
        public static string AuthenticationUi_WindowTitle {
            get {
                return ResourceManager.GetString("AuthenticationUi_WindowTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Last.fm Desktop Scrobbler.
        /// </summary>
        public static string General_ApplicationTitle {
            get {
                return ResourceManager.GetString("General_ApplicationTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unknown track by &apos;{0}&apos;.
        /// </summary>
        public static string MediaHelper_TrackDescription_ArtistOnly {
            get {
                return ResourceManager.GetString("MediaHelper_TrackDescription_ArtistOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos; by &apos;{1}&apos;.
        /// </summary>
        public static string MediaHelper_TrackDescription_Complete {
            get {
                return ResourceManager.GetString("MediaHelper_TrackDescription_Complete", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &apos;{0}&apos;.
        /// </summary>
        public static string MediaHelper_TrackDescription_TrackOnly {
            get {
                return ResourceManager.GetString("MediaHelper_TrackDescription_TrackOnly", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to An unknown track by an unknown artist.
        /// </summary>
        public static string MediaHelper_TrackDescription_Unknown {
            get {
                return ResourceManager.GetString("MediaHelper_TrackDescription_Unknown", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Downloading: {0}%.
        /// </summary>
        public static string NotificationThread_DownloadProgressUpdated {
            get {
                return ResourceManager.GetString("NotificationThread_DownloadProgressUpdated", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to download the latest version due to an error:\r\n{0}.
        /// </summary>
        public static string NotificationThread_FailedToDownload {
            get {
                return ResourceManager.GetString("NotificationThread_FailedToDownload", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Now Playing....
        /// </summary>
        public static string NotificationThread_NowPlayingDefault {
            get {
                return ResourceManager.GetString("NotificationThread_NowPlayingDefault", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checking Scrobble State....
        /// </summary>
        public static string NotificationThread_Status_CheckingScrobbleStatus {
            get {
                return ResourceManager.GetString("NotificationThread_Status_CheckingScrobbleStatus", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Ready to install..
        /// </summary>
        public static string NotificationThread_Status_ReadyToInstall {
            get {
                return ResourceManager.GetString("NotificationThread_Status_ReadyToInstall", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scrobbling {0} item(s).....
        /// </summary>
        public static string NotificationThread_Status_Scrobbling {
            get {
                return ResourceManager.GetString("NotificationThread_Status_Scrobbling", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scrobbling is paused..
        /// </summary>
        public static string NotificationThread_Status_ScrobblingPaused {
            get {
                return ResourceManager.GetString("NotificationThread_Status_ScrobblingPaused", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Starting up....
        /// </summary>
        public static string NotificationThread_Status_StartingUp {
            get {
                return ResourceManager.GetString("NotificationThread_Status_StartingUp", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Waiting to Scrobble....
        /// </summary>
        public static string NotificationThread_Status_WaitingToScrobble {
            get {
                return ResourceManager.GetString("NotificationThread_Status_WaitingToScrobble", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Connecting....
        /// </summary>
        public static string NotificationThread_StatusBar_Connecting {
            get {
                return ResourceManager.GetString("NotificationThread_StatusBar_Connecting", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Download v{0}....
        /// </summary>
        public static string NotificationThread_TrayMenu_DownloadNewVersion {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_DownloadNewVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &amp;Enable Scrobbling.
        /// </summary>
        public static string NotificationThread_TrayMenu_EnableScrobbling {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_EnableScrobbling", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to E&amp;xit.
        /// </summary>
        public static string NotificationThread_TrayMEnu_Exit {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMEnu_Exit", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Install v{0}....
        /// </summary>
        public static string NotificationThread_TrayMenu_InstallNewVersion {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_InstallNewVersion", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &amp;Love this Track.
        /// </summary>
        public static string NotificationThread_TrayMenu_Love_this_Track {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_Love_this_Track", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Love {0}.
        /// </summary>
        public static string NotificationThread_TrayMenu_LoveTrack {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_LoveTrack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to New Version Available.
        /// </summary>
        public static string NotificationThread_TrayMenu_NewVersionAvailableDefault {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_NewVersionAvailableDefault", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &amp;Settings.
        /// </summary>
        public static string NotificationThread_TrayMenu_Show {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_Show", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Unlove {0}.
        /// </summary>
        public static string NotificationThread_TrayMenu_Un_Love {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_Un_Love", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to &amp;View your Last.fm Profile.
        /// </summary>
        public static string NotificationThread_TrayMenu_ViewYourProfile {
            get {
                return ResourceManager.GetString("NotificationThread_TrayMenu_ViewYourProfile", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Failed to scrobble {0} track(s)..
        /// </summary>
        public static string PopupNotifications_FailedToScrobble {
            get {
                return ResourceManager.GetString("PopupNotifications_FailedToScrobble", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Version {0} of the Desktop Scrobbler is now available to download..
        /// </summary>
        public static string PopupNotifications_NewVersionAvailable {
            get {
                return ResourceManager.GetString("PopupNotifications_NewVersionAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scrobbled {0} track(s)..
        /// </summary>
        public static string PopupNotifications_ScrobbleSuccess {
            get {
                return ResourceManager.GetString("PopupNotifications_ScrobbleSuccess", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Now scrobbling as &apos;{0}&apos;..
        /// </summary>
        public static string PopupNotifications_SuccessfullyAuthorized {
            get {
                return ResourceManager.GetString("PopupNotifications_SuccessfullyAuthorized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Now playing: {0}.
        /// </summary>
        public static string PopupNotifications_TrackChanged {
            get {
                return ResourceManager.GetString("PopupNotifications_TrackChanged", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Current track: {0}.
        /// </summary>
        public static string ScrobblerUi_CurrentTrack {
            get {
                return ResourceManager.GetString("ScrobblerUi_CurrentTrack", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Settings....
        /// </summary>
        public static string ScrobblerUi_LinkSettings_Closed {
            get {
                return ResourceManager.GetString("ScrobblerUi_LinkSettings_Closed", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Settings &lt;&lt;.
        /// </summary>
        public static string ScrobblerUi_LinkSettings_Open {
            get {
                return ResourceManager.GetString("ScrobblerUi_LinkSettings_Open", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Are you sure you want to log out?.
        /// </summary>
        public static string ScrobblerUi_LogoutUser_Message {
            get {
                return ResourceManager.GetString("ScrobblerUi_LogoutUser_Message", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Close / Minimize to Tray.
        /// </summary>
        public static string ScrobblerUi_Settings_CloseMinimizeToTray {
            get {
                return ResourceManager.GetString("ScrobblerUi_Settings_CloseMinimizeToTray", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to General Settings.
        /// </summary>
        public static string ScrobblerUi_Settings_GeneralSettingsTitle {
            get {
                return ResourceManager.GetString("ScrobblerUi_Settings_GeneralSettingsTitle", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scrobbler Plugins.
        /// </summary>
        public static string ScrobblerUi_Settings_ScrobblePlugins_Title {
            get {
                return ResourceManager.GetString("ScrobblerUi_Settings_ScrobblePlugins_Title", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Select the plugins to enable:.
        /// </summary>
        public static string ScrobblerUi_Settings_ScrobblePluginsEnableMessage {
            get {
                return ResourceManager.GetString("ScrobblerUi_Settings_ScrobblePluginsEnableMessage", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show Scrobble Notifications.
        /// </summary>
        public static string ScrobblerUi_Settings_ShowScrobbles {
            get {
                return ResourceManager.GetString("ScrobblerUi_Settings_ShowScrobbles", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Show Track Changes.
        /// </summary>
        public static string ScrobblerUi_Settings_ShowTrackChanges {
            get {
                return ResourceManager.GetString("ScrobblerUi_Settings_ShowTrackChanges", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Start Minimized.
        /// </summary>
        public static string ScrobblerUi_Settings_StartMinimized {
            get {
                return ResourceManager.GetString("ScrobblerUi_Settings_StartMinimized", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Checking connection to Last.fm....
        /// </summary>
        public static string ScrobblerUi_Status_ConnectingToLastfm {
            get {
                return ResourceManager.GetString("ScrobblerUi_Status_ConnectingToLastfm", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to A connection to Last.fm is not available..
        /// </summary>
        public static string ScrobblerUi_Status_ConnectionToLastfmNotAvailable {
            get {
                return ResourceManager.GetString("ScrobblerUi_Status_ConnectionToLastfmNotAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Loading plugins....
        /// </summary>
        public static string ScrobblerUi_Status_LoadingPlugins {
            get {
                return ResourceManager.GetString("ScrobblerUi_Status_LoadingPlugins", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scrobbling Disabled (No Plugins Available / Enabled)....
        /// </summary>
        public static string ScrobblerUi_Status_NoPluginsAvailable {
            get {
                return ResourceManager.GetString("ScrobblerUi_Status_NoPluginsAvailable", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Not Logged In..
        /// </summary>
        public static string ScrobblerUi_Status_NotLoggedIn {
            get {
                return ResourceManager.GetString("ScrobblerUi_Status_NotLoggedIn", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Waiting for you to log in....
        /// </summary>
        public static string ScrobblerUi_Status_WaitingForAuthorization {
            get {
                return ResourceManager.GetString("ScrobblerUi_Status_WaitingForAuthorization", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Terms of use....
        /// </summary>
        public static string ScrobblerUi_TermsOfUse {
            get {
                return ResourceManager.GetString("ScrobblerUi_TermsOfUse", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Scrobbling as {0}.
        /// </summary>
        public static string ScrobblerUi_UserLoggedInText {
            get {
                return ResourceManager.GetString("ScrobblerUi_UserLoggedInText", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log In....
        /// </summary>
        public static string ScrobblerUi_UserLogin {
            get {
                return ResourceManager.GetString("ScrobblerUi_UserLogin", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Log Out....
        /// </summary>
        public static string ScrobblerUi_UserLogout {
            get {
                return ResourceManager.GetString("ScrobblerUi_UserLogout", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to (Offline) {0}.
        /// </summary>
        public static string ScrobblerUi_UserOffline {
            get {
                return ResourceManager.GetString("ScrobblerUi_UserOffline", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to You must log in to scrobble to your Last.fm account, so the application will now close..
        /// </summary>
        public static string ScrobblerUi_ValidUserAccountRequiredMessage {
            get {
                return ResourceManager.GetString("ScrobblerUi_ValidUserAccountRequiredMessage", resourceCulture);
            }
        }
    }
}
