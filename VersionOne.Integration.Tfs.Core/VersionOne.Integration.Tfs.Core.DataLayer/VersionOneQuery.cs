using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using VersionOne.SDK.APIClient;

namespace VersionOne.Integration.Tfs.Core.DataLayer
{
    public class VersionOneQuery
    {
        public readonly VersionOneSettings Settings;
        public readonly VersionOneAPIConnector processor;

        public VersionOneQuery(VersionOneSettings settings)
        {
            Settings = settings;
            ProxyProvider proxyProvider = ((settings.ProxySettings != null) && settings.ProxySettings.ProxyIsEnabled) ? new ProxyProvider(settings.ProxySettings.Url, settings.ProxySettings.Username, settings.ProxySettings.Password, settings.ProxySettings.Domain) : null;
            processor = new VersionOneAPIConnector(settings.Path, null, proxyProvider).WithVersionOneUsernameAndPassword(settings.Username, settings.Password).WithWindowsIntegratedAuthentication();
        }
        public void SetUpstreamUserAgent(string userAgent)
        {
            processor.SetUpstreamUserAgent(userAgent);
        }
        public List<List<WorkitemDto>> GetActiveWorkitems()
        {
            string strAllItems = string.Empty;

            Stream streamAllItems = processor.HttpPost("/query.v1", System.Text.Encoding.UTF8.GetBytes(getActiveWorkitemQuery()), "application/json");

            using (StreamReader reader = new StreamReader(streamAllItems, Encoding.UTF8))
            {
                strAllItems = reader.ReadToEnd();
            }

            return JsonConvert.DeserializeObject<List<List<WorkitemDto>>>(strAllItems);
        }

        private string getActiveWorkitemQuery()
        {
            return @"
                 from: PrimaryWorkitem
                 select:
                  - Name
                  - Number
                  - from: Owners
                    select:
                     - Username
                  - AssetType
                  - from: Children
                    select:
                     - Name
                     - Number
                     - from: Owners
                       select:
                       - Username
                     - AssetType
                    filter:
                     - AssetState='Active'
                     - AssetType='Task'|AssetType='Test'
                 filter:
                  - Timebox.State.Code='ACTV'
                  - AssetState='Active'
                 ";
        }

        public class WorkitemDto
        {
            public string Number { get; set; }

            public string Name { get; set; }

            public string AssetType { get; set; }

            public List<WorkitemDto> Children { get; set; }

            public List<OwnerDto> Owners { get; set; }
        }

        public class OwnerDto
        {
            public string Username { get; set; }
        }
    }
}
