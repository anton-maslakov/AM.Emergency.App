﻿using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Common.Helper;
using System.Collections.Generic;
using System.Web;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Attributes
{
    public class AdminAttribute: AuthorizeAttribute
    {
        private IRoleProvider _roleProvider;

        public AdminAttribute(IRoleProvider roleProvider)
        {
            ErrorHandlingHelper.IfArgumentNullException(roleProvider, "IRoleProvider");
            _roleProvider = roleProvider;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            var currentUser = HttpContext.Current.User;
            List<string> roleList = _roleProvider.GetAllRoles();
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