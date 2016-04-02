using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;
using System.Web.Http;

namespace Epam.Wunderlist.WebApp
{
    public static class ApiControllerExtensions
    {
        public static int GetCurrentUserId(this ApiController controller)
        {
                return Int32.Parse(((ClaimsIdentity)controller.User.Identity).Claims
                    .FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value);
        }

        public static bool UserIsAdmin(this ApiController controller)
        {
            return ((ClaimsIdentity)controller.User.Identity).Claims
                .FirstOrDefault(x => x.Type == ClaimTypes.Role).Value.ToUpper() == "TRUE";
        }

        public static HttpResponseBuilder CreateResponseBuilder(this ApiController controller)
        {
            return new HttpResponseBuilder(controller.User.Identity, controller.Request);
        }
    }
}