using FileSystem.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;


namespace WebSite.Controllers
{
    public class SystemController : ApiController
    {
        private readonly IFileSystemService _service;

        public SystemController(IFileSystemService service)
        {
            _service = service;
        }

        // GET api/system/GetDrives
        public IEnumerable<string> GetDrives()
        {
            return _service.GetAllDrives();
        }

        // GET api/system/GetFolders/path
        public IEnumerable<string> GetFolders(string path)
        {
            return _service.GetSubFolders(path);
        }

        // GET api/system/GetFiles/path
        public IEnumerable<string> GetFiles(string path)
        {
            return _service.GetFiles(path);
        }

        #region without implementation

        // POST api/system
        public void CreateFolder([FromBody]PathInfo value)
        {
        }

        public void CreateFile([FromBody]PathInfo value)
        {
        }
      
        // DELETE api/system/5
        public void DeleteFolder(int id)
        {

        }

        public void DeleteFile()
        {

        }
        #endregion
    }
}
