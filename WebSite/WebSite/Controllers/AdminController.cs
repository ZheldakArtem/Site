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

        public HttpResponseMessage CreateRole(string name)
        {
            return null;
        }
        #endregion

        private IEnumerable<object> GetUsersWhithRole()
        {
            IList<object> users = new List<object>();

            foreach (var role in Roles.GetAllRoles())
            {
                foreach (var user in Roles.GetUsersInRole(role))
                {
                    users.Add(new { Name = user, Role = role });
                }
            }
            return users;
        }
    }
}
