using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebSite;
using WebSite.Controllers;
using Moq;
using FileSystem.Interfaces;

namespace WebSite.Tests.Controllers
{
    [TestClass]
    public class SystemControllerTest
    {
        [TestMethod]
        public void GetDrives_ReturnAllDrives()
        {
            Mock<IFileSystemService> mock = new Mock<IFileSystemService>();
            //TODO
        }

    }
}
