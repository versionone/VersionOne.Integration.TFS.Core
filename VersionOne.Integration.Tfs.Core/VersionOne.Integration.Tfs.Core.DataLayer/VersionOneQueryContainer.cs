using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;

namespace VersionOne.Integration.Tfs.Core.DataLayer
{
    public class VersionOneQueryContainer
    {
        private readonly ILog logger = LogManager.GetLogger(typeof(VersionOneQueryContainer));

        private VersionOneQuery component;

        public VersionOneQuery GetVersionOneHelper(VersionOneSettings settings)
        {
            if (component == null || DifferentSettingsRequired(settings))
            {
                component = new VersionOneQuery(settings);

                logger.Info("Successfully connected to VersionOne.");
            }

            return component;
        }

        private bool DifferentSettingsRequired(VersionOneSettings settings)
        {
            return component == null || !component.Settings.Equals(settings);
        }
    }
}
