using System;
using System.Collections.Generic;
using System.Net;
using VersionOne.Integration.Tfs.Core.DTO;
using VersionOne.Integration.Tfs.Core.Structures;
using Newtonsoft.Json;
using VersionOne.Integration.Tfs.Core.DataLayer.Providers;
using VersionOne.Integration.Tfs.Core.Adapters;

namespace VersionOne.Integration.Tfs.Core.DataLayer
{
    public interface IHttpClient
    {
        byte[] Put(string url, byte[] body);
        string Get(string url);
    }

    public class HttpClient : IHttpClient
{
        private readonly WebClient _client;

        public HttpClient(WebClient client = null)
        {
            _client = client ?? new WebClient();
        }

        public byte[] Put(string url, byte[] body)
        {
            return _client.UploadData(url, body);
        }

        public string Get(string url)
        {
            return _client.DownloadString(url);
        }
}

    public class ConfigurationProxy
    {
        private readonly IHttpClient _client;
        private readonly string _baseUrl;

        public static string ProbeServerConfig()
        {
            // look in web.config
            // return convention
            // port-scan local box
            return "http://localhost:9090/";
        }
        public ConfigurationProxy(IHttpClient client = null, string baseListenerUrl = null)
        {
            _client = client ?? new HttpClient();
            if (string.IsNullOrEmpty(baseListenerUrl))
            {
                _baseUrl = new DefaultConfigurationProvider().BaseListenerUrl.ToString();
            }
            else
            {
                _baseUrl = baseListenerUrl;
            }
        }

        public string BaseListenerUrl
        {
            get { return _baseUrl; }
        }

        public string ConfigurationUrl
        {
            get { return new Uri(new Uri(BaseListenerUrl), UriElements.ConfigurationPath).ToString(); }
        }

        public string ListenerUrl
        {
            get { return new Uri(new Uri(BaseListenerUrl), UriElements.ServiceName).ToString(); }
        }

        public Dictionary<string, string> Store(TfsServerConfiguration config)
        {
            var json = JsonConvert.SerializeObject(config);
            if (config.IsWindowsIntegratedSecurity)
            {
                AppPoolConfigurationAdapter.SetAppPoolIdentity(config.WebSiteName, config.VersionOneUserName, config.VersionOnePassword);
            }
            var result = _client.Put(ConfigurationUrl, System.Text.Encoding.UTF8.GetBytes(json));
            var body = System.Text.Encoding.UTF8.GetString(result);
            return JsonConvert.DeserializeObject<Dictionary<string, string>>(body);
        }

        public TfsServerConfiguration Retrieve()
        {
            var result = _client.Get(ConfigurationUrl);
            var body = result;
            return JsonConvert.DeserializeObject<TfsServerConfiguration>(body);
        }

        public TfsServerConfiguration Retrieve(Func<string, string> unprotect)
        {
            var result = _client.Get(ConfigurationUrl).Replace("\"",string.Empty);
            var body = unprotect(result);
            return JsonConvert.DeserializeObject<TfsServerConfiguration>(body);
        }

    }

}