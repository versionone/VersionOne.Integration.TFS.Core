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
        public static void SetAppPoolIdentity(string appPoolName, string userName, string password)
        {
            appPoolName = string.IsNullOrEmpty(appPoolName)?GetApplicationPoolName():appPoolName;
            using (ServerManager serverManager = new ServerManager())
            {
                ApplicationPool appPool = serverManager.ApplicationPools.Where(ap => ap.Name == appPoolName).SingleOrDefault();
                if (appPool != null)
                {
                    appPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
                    appPool.ProcessModel.UserName = userName;
                    appPool.ProcessModel.Password = password;
                    serverManager.CommitChanges();
                    appPool.Recycle();
                }
            }
        }
        public static string GetApplicationPoolName()
        {
            ServerManager manager = new ServerManager();
            string DefaultSiteName = System.Web.Hosting.HostingEnvironment.ApplicationHost.GetSiteName();
            Site defaultSite = manager.Sites[DefaultSiteName];
            string appVirtaulPath = HttpRuntime.AppDomainAppVirtualPath;

            string appPoolName = string.Empty;
            foreach (Application app in defaultSite.Applications)
            {
                string appPath = app.Path;
                if (appPath == appVirtaulPath)
                {
                    appPoolName = app.ApplicationPoolName;
                }
            }
            return appPoolName;
        }
    }
}
