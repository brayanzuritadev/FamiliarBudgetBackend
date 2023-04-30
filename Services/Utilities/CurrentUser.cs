using Data.Entity;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Services.Utilities
{
    public class CurrentUser
    {
        private readonly IHttpContextAccessor contextAccessor;

        public CurrentUser(IHttpContextAccessor contextAccessor)
        {
            this.contextAccessor = contextAccessor;
        }

        public User GetCurrentUser()
        {
            var userCurrent = contextAccessor.HttpContext.User.Identity as ClaimsIdentity;

            if (!userCurrent.IsAuthenticated)
            {
                return null;
            }
            try
            {
                var user = new User
                {
                    UserId = Int32.Parse(userCurrent.Claims.FirstOrDefault(x => x.Type == "Id").Value),
                    FamilyId = Int32.Parse(userCurrent.Claims.FirstOrDefault(x => x.Type == "FamilyId").Value),
                    RoleId = Int32.Parse(userCurrent.Claims.FirstOrDefault(x => x.Type == "RoleId").Value),
                };

                return user;
            }
            catch(Exception ex)
            {
                return null;
            }

            
        }
    }
}
