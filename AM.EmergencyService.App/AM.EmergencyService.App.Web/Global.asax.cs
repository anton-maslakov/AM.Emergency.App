using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Optimization;
using System.Web.Security;
using Newtonsoft.Json;
using AM.EmergencyService.App.Common.Models.Authorization;
using AM.EmergencyService.App.Business.Model;

namespace AM.EmergencyService.App.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
        protected void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            var cookie = HttpContext.Current.Request.Cookies.Get(FormsAuthentication.FormsCookieName);
            if (cookie != null)
            {
                var decryptedCookie = FormsAuthentication.Decrypt(cookie.Value);
                var User = JsonConvert.DeserializeObject<UserModel>(decryptedCookie.UserData);
                var userPrincipal = new UserPrincipal(User);
                HttpContext.Current.User = userPrincipal;
            }
        }
    }
}
