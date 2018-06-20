using System.Web;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Attributes
{
    public class DispatcherAttribute : AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUser = HttpContext.Current.User;
            string role = "dispatcher";
            if (currentUser != null)
            {
                if (currentUser.IsInRole(role))
                {
                    return true;
                }
                return false;
            }
            return false;
        }
    }
}