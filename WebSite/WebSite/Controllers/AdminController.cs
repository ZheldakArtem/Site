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

        public void CreateRole()
        {
        }

        public void EditRoleForUser()
        {
        }

        public void DeleteRole()
        {
        }

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
