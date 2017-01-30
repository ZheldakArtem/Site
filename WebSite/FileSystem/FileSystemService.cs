using FileSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem
{
    /// <summary>
    /// The class that implements IFileSystemService.
    /// </summary>
    public class FileSystemService : IFileSystemService
    {
        public IEnumerable<string> GetAllDrives()
        {
            DriveInfo[] drives = DriveInfo.GetDrives();

            var names = drives.Select(n => n.Name);

            return names;
        }

        public IEnumerable<string> GetSubFolders(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                throw new ArgumentException();
            }

            return Directory.GetDirectories(path);
        }

        public IEnumerable<string> GetFiles(string path)
        {
            if (string.IsNullOrEmpty(path) || !Directory.Exists(path))
            {
                throw new ArgumentException();
            }

            return Directory.GetFiles(path);

        }

        public bool CreateFolder(string path = "D:\\", string name = "New Folder")
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            var newDir = dirInfo.CreateSubdirectory(name);

            return newDir == null ? false : true;
        }

        public bool CreateFile(string path, string name)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            DirectoryInfo dirInfo = new DirectoryInfo(path);
            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            try
            {
                FileInfo newFile = new FileInfo(string.Format("{0}\\{1}", path, name));
                newFile.Create();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool DeleteFolder(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(path);

                if (!dirInfo.Exists)
                {
                    return false;
                }

                dirInfo.Delete(true);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return true;
        }

        public bool DeleteFile(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }

            FileInfo fileInf = new FileInfo(path);
            if (fileInf.Exists)
            {
                try
                {
                    fileInf.Delete();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            return true;
        }

    }
}
