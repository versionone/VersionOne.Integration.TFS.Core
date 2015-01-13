using System;

namespace VersionOne.Integration.Tfs.Core.Interfaces
{
    public interface IProxyConnectionSettings
    {
        bool ProxyIsEnabled { get; }
        Uri Uri { get; }
        string Domain { get; }
        string Username { get; }
        string Password { get; }
    }
}
