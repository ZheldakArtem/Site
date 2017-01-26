using FileSystem;
using FileSystem.Interfaces;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebSite.App_Start
{
    public static class UnityConfig
    {
        public static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();
            container.RegisterType<IFileSystemService, FileSystemService>();

            return container;
        }
    }
}