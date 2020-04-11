using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using System.Security.Principal;
using System.Net.Http;
using System.Net;

namespace Emp.WebAPILayer.Filters
{
    public class CustomAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Authorization != null)
            {
                var authToken = actionContext.Request.Headers.Authorization.Parameter;
                var decodeauthToken = System.Text.Encoding.UTF8.GetString(Convert.FromBase64String(authToken));
                var vUsrPwd = decodeauthToken.Split(':');
                if (IsAuthorizedUser(vUsrPwd[0], vUsrPwd[1]))
                {
                    Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(vUsrPwd[0]), null);
                }
                else
                    actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
             }
            else
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
        }

        private bool IsAuthorizedUser(string pusr, string ppwd)
        {
            return pusr == "admin" && ppwd == "test";
        }
    }
}