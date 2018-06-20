using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Attributes
{
    public class EditorAttribute: AuthorizeAttribute
    {
        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUser = HttpContext.Current.User;
            List<string> roleList = new List<string> { "editor", "dispatcher" };
            if (currentUser != null)
            {
                foreach (var role in roleList)
                {
                    if (currentUser.IsInRole(role))
                    {
                        return true;
                    }
                }
                return false;
            }
            return false;
        }
    }
}