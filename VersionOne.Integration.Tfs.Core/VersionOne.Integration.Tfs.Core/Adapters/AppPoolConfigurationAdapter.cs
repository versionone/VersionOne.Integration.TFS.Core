using Microsoft.Web.Administration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace VersionOne.Integration.Tfs.Core.Adapters
{
    public static class AppPoolConfigurationAdapter
    {
        public static void SetAppPoolIdentity(string webSiteName, string userName, string password)
        {

            string appPoolName = GetApplicationPoolName(webSiteName);
            using (ServerManager serverManager = new ServerManager())
            {
                ApplicationPool appPool = serverManager.ApplicationPools.Where(ap => ap.Name == appPoolName).SingleOrDefault();
                if (appPool != null)
                {
                    appPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
                    appPool.ProcessModel.UserName = userName;
                    appPool.ProcessModel.Password = password;
                    serverManager.CommitChanges();
                }
            }
        }
        public static void SetAppPoolIdentity(string webSiteName)
        {

            string appPoolName = GetApplicationPoolName(webSiteName);
            using (ServerManager serverManager = new ServerManager())
            {
                ApplicationPool appPool = serverManager.ApplicationPools.Where(ap => ap.Name == appPoolName).SingleOrDefault();
                if (appPool != null)
                {
                    appPool.ProcessModel.IdentityType = ProcessModelIdentityType.ApplicationPoolIdentity;
                    serverManager.CommitChanges();
                }
            }
        }
        public static string GetApplicationPoolName(string webSiteName)
        {
            ServerManager manager = new ServerManager();
            Site defaultSite = manager.Sites[webSiteName];
            Application appPool = defaultSite.Applications.FirstOrDefault();

            return (appPool != null) ? appPool.ApplicationPoolName : string.Empty;
        }
    }
}
