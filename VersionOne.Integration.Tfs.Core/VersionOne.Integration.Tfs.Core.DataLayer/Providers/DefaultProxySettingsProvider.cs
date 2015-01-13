using System;
using VersionOne.Integration.Tfs.Core.Interfaces;

namespace VersionOne.Integration.Tfs.Core.DataLayer.Providers
{
    public class DefaultProxySettingsProvider : IProxyConnectionSettings
    {
        public bool ProxyIsEnabled
        {
            get { return false; }
        }
        public Uri Uri
        {
            get { return new Uri("http://192.168.1.1/"); }
        }
        public string Domain
        {
            get { return "AD"; }
        }
        public string Username
        {
            get { return "Administrator"; }
        }
        public string Password
        {
            get { return "123456"; }
        }
    }
}