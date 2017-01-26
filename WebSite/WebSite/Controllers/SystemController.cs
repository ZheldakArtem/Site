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
        [HttpGet]
        public IEnumerable<string> GetDrives()
        {
            return _service.GetAllDrives();
        }

        [HttpGet]
        // GET api/system/GetFolders/path
        public IEnumerable<string> GetFolders(string path)
        {
            return _service.GetSubFolders(path);
        }

        // GET api/system/GetFiles/path
        [HttpGet]
        public IEnumerable<string> GetFiles(string path)
        {
            return _service.GetFiles(path);
        }

        #region without implementation

        // POST api/system
        [HttpPost]
        public void CreateFolder([FromBody]string value)
        {

        }

         [HttpPost]
        public void CreateFile([FromBody]string value)
        {

        }
      
        // DELETE api/system/5
        [HttpDelete]
        public void DeleteFolder(string path)
        {

        }

        //[HttpDelete]
        //public void DeleteFile()
        //{

        //}
        #endregion
    }
}
