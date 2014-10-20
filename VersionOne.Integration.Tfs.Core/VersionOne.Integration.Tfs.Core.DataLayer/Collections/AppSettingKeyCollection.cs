﻿using System.Collections.Generic;

namespace VersionOne.Integration.Tfs.Core.DataLayer.Collections
{
    /// <summary>
    /// Provides access to a recursable set of the AppSettingsKeys structure.
    /// </summary>
    public class AppSettingKeyCollection : Dictionary<string, string>
    {

        public AppSettingKeyCollection()
        {
            var instance = new AppSettingKeys();
            foreach (var field in typeof(AppSettingKeys).GetFields())
            {
                if (field.IsPrivate) continue;
                this.Add(field.Name, field.GetValue(instance) as string);
            }
        }
    }
}