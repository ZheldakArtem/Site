using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Linq;
using System.IO;
using FileSystem.Interfaces;
using System.Collections.Generic;

namespace FileSystem.Tests1
{
    [TestClass]
    public class UnitTest
    {
        private readonly string path = @"D:\";

        private readonly string fileName = "file.txt";

        private readonly string folderName = "newFolder";

        [TestMethod]
        public void GetAllDrivesOnCurrentFileSystem()
        {
            IFileSystemService fss = new FileSystemService();
            var expectedDrivesNames = DriveInfo.GetDrives().Select(n => n.Name);

            var actualNames = fss.GetAllDrives();

            CollectionAssert.AreEqual(expectedDrivesNames.ToArray(), actualNames.ToArray());

        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetSubFolders_WithNullPath_ThrowArgumentException()
        {
            IFileSystemService fss = new FileSystemService();

            fss.GetSubFolders(null);
        }

        [TestMethod]
        public void GetSubFolders_WhithValidPath()
        {
            string[] expectedNames = Directory.GetDirectories(path);

            IFileSystemService fss = new FileSystemService();

            var actual = fss.GetSubFolders(path);
           
            CollectionAssert.AreEqual(expectedNames, actual.ToArray());
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void GetFiles_WithNullPath_ThrowArgumentException()
        {
            IFileSystemService fss = new FileSystemService();

            fss.GetFiles(null);
        }

        [TestMethod]
        public void GetFiles_WithValidPath()
        {
            var expected = Directory.GetFiles(path);
            IFileSystemService fss = new FileSystemService();

            var actual = fss.GetFiles(path);

            CollectionAssert.AreEqual(expected, actual.ToArray());
        }

        [TestMethod]
        public void CreateFolder_WithNullPath_NewFolderNotCreated()
        {
            IFileSystemService fss = new FileSystemService();

            var actual = fss.CreateFolder(null, folderName);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CreateFolder_WhithValidArguments_FolderCreated()
        {
            var dict = new Dictionary<string, string>
            {
                { path , folderName }
            };
            IFileSystemService fss = new FileSystemService();

            var actual = fss.CreateFolder(dict.Keys.First(), dict.Values.First());

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeleteFolder_WhithNullPath_ThrowArgumentException()
        {
            IFileSystemService fss = new FileSystemService();
            var actual = fss.DeleteFolder(null);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void DeleteFolder_WithValidArgments_FolderDeleted()
        {
            string fullPath = path + folderName;
            IFileSystemService fss = new FileSystemService();

            var actual = fss.DeleteFolder(fullPath);

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void CreateFile_WhithNullPath_NewFileNotCreated()
        {
            IFileSystemService fss = new FileSystemService();

            var actual = fss.CreateFile(null, fileName);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void CreateFile_WhithValidArguments_FileCreated()
        {
            var dict = new Dictionary<string, string>
            {
                { path , fileName }
            };
            IFileSystemService fss = new FileSystemService();

            var actual = fss.CreateFolder(dict.Keys.First(), dict.Values.First());

            Assert.IsTrue(actual);
        }

        [TestMethod]
        public void DeleteFile_WhithNullPath_ThrowArgumentException()
        {
            IFileSystemService fss = new FileSystemService();
            var actual = fss.DeleteFile(null);

            Assert.IsFalse(actual);
        }

        [TestMethod]
        public void DeleteFile_WithValidArgments_FolderDeleted()
        {
            string fullPath = path + fileName;
            IFileSystemService fss = new FileSystemService();

            var actual = fss.DeleteFile(path);

            Assert.IsTrue(actual);
        }

    }

}
