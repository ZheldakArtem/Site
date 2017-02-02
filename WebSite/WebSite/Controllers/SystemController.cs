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

        [HttpGet]
        public IEnumerable<string> GetDrives()
        {
            return _service.GetAllDrives();
        }

        [HttpGet]
        public IEnumerable<string> GetFolders(string path)
        {
            return _service.GetSubFolders(path);
        }

        [HttpGet]
        public IEnumerable<string> GetFiles(string path)
        {
            return _service.GetFiles(path);
        }

        [HttpPost]
        public HttpResponseMessage CreateFolder(string path, string name)
        {
            if (!_service.CreateFolder(path, name))
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage CreateFile(string path, string name)
        {
            try
            {
                if (!_service.CreateFile(path, name))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteFolder(string path)
        {
            try
            {
                if (!_service.DeleteFolder(path))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        [HttpDelete]
        public HttpResponseMessage DeleteFile(string path)
        {
            try
            {
                if (!_service.DeleteFile(path))
                {
                    return Request.CreateResponse(HttpStatusCode.BadRequest);
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

    }
}
