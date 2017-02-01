using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileSystem.Interfaces
{
    /// <summary>
    /// The interface provides the behavior of work with the file system
    /// </summary>
    public interface IFileSystemService
    {
        /// <summary>
        /// The method returning all drivers which used on current file system.
        /// </summary>
        /// <returns>drives name array</returns>
        IEnumerable<string> GetAllDrives();

        /// <summary>
        ///  The method returning all subfolders on current file system.
        /// </summary>
        /// <param name="path">Physical path of the parent folder.</param>
        /// <returns>Subfolders' name array.</returns>
        IEnumerable<string> GetSubFolders(string path);

        /// <summary>
        ///  The method returning all files on current file system.
        /// </summary>
        /// <param name="path">Physical path of the parent folder.</param>
        /// <returns>Files' name array</returns>
        IEnumerable<string> GetFiles(string path);

        /// <exception cref="System.Exception></exception>
        /// <summary>
        ///  The method remove the file on current file system.
        /// </summary>
        /// <param name="path">The Physical path of the file.</param>
        /// <returns>The method return "true" if the file was removed otherwise - "false".</returns>
        bool DeleteFile(string path);

        /// <summary>
        ///  The method remove the folder on current file system.
        /// </summary>
        /// <param name="path">The Physical path of the folder.</param>
        /// <returns>The method return "true" if the folder was removed otherwise - "false".</returns>
        bool DeleteFolder(string path);

        /// <summary>
        /// Create new file.
        /// </summary>
        /// <param name="path">The Physical path of the file.</param>
        /// <param name="name">The name of file.</param>
        /// <returns>The method return "true" if the file was created otherwise - "false".</returns>
        bool CreateFolder(string path = "D:\\", string name = "New Folder");

        /// <summary>
        /// Create new folder.
        /// </summary>
        /// <param name="path">The Physical path of the folder.</param>
        /// <param name="name">The name of file.</param>
        /// <returns>The method return "true" if the folder was created otherwise - "false".</returns>
        bool CreateFile(string path, string name);
    }
}
