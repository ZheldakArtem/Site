using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Security;
using WebMatrix.WebData;
using WebSite.Filters;
using WebSite.Models;

namespace WebSite.Controllers
{
    [Authorize(Roles = "admin")]
    [InitializeSimpleMembership]
    public class AdminController : ApiController
    {
        public IEnumerable<object> GetUsers()
        {
            return GetUsersWhithRole();
        }

        public IEnumerable<string> GetRoles()
        {
            return Roles.GetAllRoles();
        }

        [HttpPut]
        public HttpResponseMessage EditRoleForUser(string userName, string roleName)
        {
            try
            {
                Roles.AddUserToRole(userName, roleName);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK);
        }

        #region TODO
        public HttpResponseMessage DeleteRole()
        {
            return null;
        }

        #endregion
        [HttpPost]
        public HttpResponseMessage CreateRole(string name)
        {
            try
            {
                Roles.CreateRole(name);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, ex.Message);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        private IEnumerable<object> GetUsersWhithRole()
        {
            IList<object> users = new List<object>();

            foreach (var role in Roles.GetAllRoles())
            {
                foreach (var user in Roles.GetUsersInRole(role))
                {
                    users.Add(new { name = user, role = role });
                }
            }
            return users;
        }
    }
}
