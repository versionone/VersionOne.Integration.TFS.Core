﻿using System;
using System.Collections.Generic;
using System.IO;
using VersionOne.Integration.Tfs.Core.Interfaces;
using VersionOne.Integration.Tfs.Core.Structures;
using VersionOne.Integration.Tfs.Core.DataLayer.Collections;

namespace VersionOne.Integration.Tfs.Core.DataLayer.Providers
{
    /// <summary>
    /// Provides access to V1 specific settings in the appSettings section of the root web config.
    /// </summary>
    public class ConfigurationProvider : IConfigurationProvider
    {
        private readonly IConfigurationProvider _configurationDefaults;
        private readonly Dictionary<string, string> _savedSettings; 

        public ConfigurationProvider()
        {
            _configurationDefaults = new DefaultConfigurationProvider();
            _savedSettings = GetExistingSettings();
        }

        private static Dictionary<string, string> GetExistingSettings()
        {
            if (Directory.Exists(Paths.ConfigurationDirectory) == false
                || File.Exists(Paths.ConfigurationPath) == false) return null;

            var returnValue = new Dictionary<string, string>();

            using (var reader = new StreamReader(Paths.ConfigurationPath))
            {
                string delimitedLine;
                while ((delimitedLine = reader.ReadLine()) != null)
                {
                    var parsedValues = delimitedLine.Split(Seperators.Primary);
                    returnValue.Add(parsedValues[0], parsedValues[1]);
                }
            }

            return returnValue;

        }

        public ConfigurationProvider(Func<string, string> unprotect)
        {
            _configurationDefaults = new DefaultConfigurationProvider();
            _savedSettings = GetExistingSettings(unprotect);
        }

        private static Dictionary<string, string> GetExistingSettings(Func<string, string> unprotect)
        {
            if (Directory.Exists(Paths.ConfigurationDirectory) == false
                || File.Exists(Paths.ConfigurationPath) == false) return null;

            var returnValue = new Dictionary<string, string>();

            using (var reader = new StreamReader(Paths.ConfigurationPath))
            {
                string config = unprotect(reader.ReadToEnd());
                foreach (string delimitedLine in config.Split(new string[] { Environment.NewLine }, StringSplitOptions.None))
                {
                    var parsedValues = delimitedLine.Split(Seperators.Primary);
                    returnValue.Add(parsedValues[0], parsedValues[1]);
                }
            }

            
            return returnValue;

        }


        public void ClearAllSettings()
        {
            if (File.Exists(Paths.ConfigurationPath)) File.Delete(Paths.ConfigurationPath);
        }

        public bool IsWindowsIntegratedSecurity
        {
            get { return ProviderUtilities.GetSetting(_savedSettings, AppSettingKeys.IsWindowsIntegratedSecurity, _configurationDefaults.IsWindowsIntegratedSecurity); }
        }

        public Uri VersionOneUrl
        {
            get { return ProviderUtilities.GetUri(_savedSettings, AppSettingKeys.VersionOneUrl, _configurationDefaults.VersionOneUrl); }
        }

        public string VersionOneUserName
        {
            get { return ProviderUtilities.GetSetting(_savedSettings, AppSettingKeys.VersionOneUserName, _configurationDefaults.VersionOneUserName); }
        }

        public string VersionOnePassword
        {
            get { return ProviderUtilities.GetSetting(_savedSettings, AppSettingKeys.VersionOnePassword, _configurationDefaults.VersionOnePassword); }
        }

        public Uri TfsUrl
        {
            get { return ProviderUtilities.GetUri(_savedSettings, AppSettingKeys.TfsUrl, _configurationDefaults.TfsUrl); }
        }

        public Uri BaseListenerUrl
        {
            get { return ProviderUtilities.GetUri(_savedSettings, AppSettingKeys.BaseListenerUrl, _configurationDefaults.BaseListenerUrl); }
        }

        public Uri TfsListenerUrl
        {
            get { return ProviderUtilities.GetUri(_savedSettings, AppSettingKeys.TfsListenerUrl, _configurationDefaults.TfsListenerUrl); }
        }

        public Uri ConfigurationUrl 
        {
            get{ return ProviderUtilities.GetUri(_savedSettings, AppSettingKeys.ConfigurationUrl, _configurationDefaults.ConfigurationUrl); }
        }

        public string TfsUserName
        {
            get { return ProviderUtilities.GetSetting(_savedSettings, AppSettingKeys.TfsUserName, _configurationDefaults.TfsUserName); }
        }

        public string TfsPassword
        {
            get { return ProviderUtilities.GetSetting(_savedSettings, AppSettingKeys.TfsPassword, _configurationDefaults.TfsPassword); }
        }

        public string TfsWorkItemRegex
        {
            get { return ProviderUtilities.GetSetting(_savedSettings, AppSettingKeys.TfsWorkItemRegex, _configurationDefaults.TfsWorkItemRegex); }
        }

        public bool DebugMode
        {
            get { return ProviderUtilities.GetSetting(_savedSettings, AppSettingKeys.DebugMode, _configurationDefaults.DebugMode); }
        }

        public IProxyConnectionSettings ProxySettings
        {
            get { return new ProxySettingsProvider(_savedSettings); }
        }

    }
}