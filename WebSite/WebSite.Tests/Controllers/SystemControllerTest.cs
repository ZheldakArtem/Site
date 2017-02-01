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
using System.Net.Http;
using System.Net;

namespace WebSite.Tests.Controllers
{
    [TestClass]
    public class SystemControllerTest
    {
        private static Mock<IFileSystemService> mock = new Mock<IFileSystemService>();

        private static SystemController controller = new SystemController(mock.Object);

        [TestMethod]
        public void GetDrives_ReturnAllDrives()
        {
            mock.Setup(m => m.GetAllDrives()).Returns(new List<string>() { @"D:\", @"C\" });
            //expected
            int actualCountOfDrive = 2;

            var actual = controller.GetDrives().Count();

            Assert.AreEqual(actualCountOfDrive, actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFolders_WhithNullArg_Throw_ArgumentNullException()
        {
            mock.Setup(m => m.GetSubFolders(null)).Throws<ArgumentNullException>();

            controller.GetFolders(null);
        }

        [TestMethod]
        public void GetFolders_WhithValidArg()
        {
            mock.Setup(m => m.GetSubFolders(It.IsAny<string>())).Returns(new List<string>());

            var actual = controller.GetFolders(@"D:\");

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void GetFiles_WithNullArg_Throw_ArgumentNullException()
        {
            mock.Setup(m => m.GetFiles(null)).Throws<ArgumentException>();

            controller.GetFiles(null);
        }

        [TestMethod]
        public void GetFiles_WhithValidArg()
        {
            mock.Setup(m => m.GetFiles(It.IsAny<string>())).Returns(new List<string>());

            var actual = controller.GetFiles(@"D:\");

            Assert.IsNotNull(actual);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateFolder_WithNullArg_Throw_ArgumentNullException()
        {
            mock.Setup(m => m.CreateFolder(null, null)).Throws<ArgumentNullException>();

            controller.CreateFolder(null, null);
        }

        [TestMethod]
        public void CreateFolder_WithValidArg()
        {
            mock.Setup(m => m.CreateFolder(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            controller.Request = new HttpRequestMessage();

            var actual = controller.CreateFolder(@"D:\", "newFolder");

            Assert.IsTrue(actual.IsSuccessStatusCode);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CreateFile_WithNullArg_Throw_ArgumentNullException()
        {
            mock.Setup(m => m.CreateFile(null, null)).Throws<ArgumentNullException>();

            controller.CreateFile(null, null);
        }

        [TestMethod]
        public void CreateFile_WithValidArg()
        {
            mock.Setup(m => m.CreateFile(It.IsAny<string>(), It.IsAny<string>())).Returns(true);
            controller.Request = new HttpRequestMessage();

            var actual = controller.CreateFile(@"D:\", "newFolder");

            Assert.IsTrue(actual.IsSuccessStatusCode);
        }


    }
}
