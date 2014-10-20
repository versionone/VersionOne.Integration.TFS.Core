﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace VersionOne.Integration.Tfs.Core.Extensions
{
    public static class ReferenceLoader
    {
        static AppDomain Domain;
        static Dictionary<string, string[]> SupportedDlls;
        
        public static void ResolveDlls(AppDomain domain, Dictionary<string, string[]> supportedDlls)
        {
            Domain = domain;
            SupportedDlls = supportedDlls;
            domain.AssemblyResolve += Domain_AssemblyResolve;
        }

        private static Assembly Domain_AssemblyResolve(object sender, ResolveEventArgs args)
        {
            Domain.AssemblyResolve -= Domain_AssemblyResolve;
            Assembly assembly = null;
            if (SupportedDlls.ContainsKey(args.Name.Split(',').First()))
            {
                assembly = resolveSupportedAssembly(SupportedDlls[args.Name.Split(',').First()]);
            }
            Domain.AssemblyResolve += Domain_AssemblyResolve;
            return assembly;
        }
        private static Assembly resolveSupportedAssembly(string[] versions)
        {
            Assembly assembly = null;
            foreach (string version in versions)
            {
                try
                {
                    assembly = Assembly.Load(version);
                    return assembly;
                }
                catch { }
            }
            return assembly;
        }
    }
}
