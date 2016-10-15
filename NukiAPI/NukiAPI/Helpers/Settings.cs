using System;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace NukiAPI.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters.
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants

        private const string BaseUriKey = "baseuri";
        private static readonly string BaseUriDefault = String.Empty;

        private const string ApiKeyKey = "apikey";
        private static readonly string ApiKeyDefault = String.Empty;

        private const string LockIdKey = "lockid";
        private static readonly int LockIdDefault = -1;

        private const string LockNameKey = "lockname";
        private static readonly string LockNameDefault = String.Empty;

        private const string ConfirmLockKey = "confirm_lock";
        private static readonly bool ConfirmLockDefault = true;

        private const string ConfirmUnlockKey = "confirm_unlock";
        private static readonly bool ConfirmUnlockDefault = true;

        #endregion

        public static string BaseUri
        {
            get { return AppSettings.GetValueOrDefault(BaseUriKey, BaseUriDefault); }
            set { AppSettings.AddOrUpdateValue(BaseUriKey, value); }
        }

        public static string ApiKey
        {
            get { return AppSettings.GetValueOrDefault(ApiKeyKey, ApiKeyDefault); }
            set { AppSettings.AddOrUpdateValue(ApiKeyKey, value); }
        }

        public static int LockId
        {
            get { return AppSettings.GetValueOrDefault(LockIdKey, LockIdDefault); }
            set { AppSettings.AddOrUpdateValue(LockIdKey, value); }
        }

        public static string LockName
        {
            get { return AppSettings.GetValueOrDefault(LockNameKey, LockNameDefault); }
            set { AppSettings.AddOrUpdateValue(LockNameKey, value); }
        }

        public static bool ConfirmLock
        {
            get { return AppSettings.GetValueOrDefault(ConfirmLockKey, ConfirmLockDefault); }
            set { AppSettings.AddOrUpdateValue(ConfirmLockKey, value); }
        }

        public static bool ConfirmUnlock
        {
            get { return AppSettings.GetValueOrDefault(ConfirmUnlockKey, ConfirmUnlockDefault); }
            set { AppSettings.AddOrUpdateValue(ConfirmUnlockKey, value); }
        }
    }
}