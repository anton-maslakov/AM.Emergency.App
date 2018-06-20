using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Web.Models;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class AccountController : Controller
    {
        private ILogger _logger;
        private IUserLogin _userLogin;
        public AccountController(ILogger logger, IUserLogin userLogin)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(userLogin, "IUserLogin");
            _logger = logger;
            _userLogin = userLogin;
        }

        // GET: Account
        public ActionResult LogIn(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult LogIn(UserViewModel model, string returnUrl)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            _userLogin.LogIn(model.Login, model.Password);
            return RedirectToLocal(returnUrl);
        }
        
        public ActionResult LogOut()
        {
            _userLogin.LogOut();
            return RedirectToAction("Index", "Home");
        }
        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}