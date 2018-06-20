using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models.Authorization;
using AM.EmergencyService.App.Web.Models.Account;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class AccountController : Controller
    {
        private IUserLogin _userLogin;
        private IUserProvider _userProvider;
        private IRoleProvider _roleProvider;
        private IUserService _userService;
        public AccountController(IUserLogin userLogin, IUserProvider userProvider, IRoleProvider roleProvider, IUserService userService)
        {
            ErrorHandlingHelper.IfArgumentNullException(userService, "IUserService");
            ErrorHandlingHelper.IfArgumentNullException(userLogin, "IUserLogin");
            ErrorHandlingHelper.IfArgumentNullException(userProvider, "IUserProvider");
            ErrorHandlingHelper.IfArgumentNullException(roleProvider, "IRoleProvider");
            _roleProvider = roleProvider;
            _userProvider = userProvider;
            _userService = userService;
            _userLogin = userLogin;
        }
        public ActionResult Index()
        {
            IEnumerable<UserViewModel> userViewModel = ToUserViewModel(_userProvider.GetAllUsers());
            return View(userViewModel);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(UserViewModel viewModel)
        {
            _userService.Create(ParseToUserModel(viewModel));
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int userId)
        {
            _userService.Delete(userId);
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int userId)
        {
            return View(ParseToViewModel(_userProvider.GetUserById(userId)));
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel viewModel)
        {
            _userService.Update(ParseToUserModel(viewModel));
            return RedirectToAction("Index");
        }

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
        public PartialViewResult UserRoles(int userId)
        {
            var roleList = _roleProvider.GetUserRoles(userId);
            return PartialView(roleList);
        }

        #region Helper
        private List<UserViewModel> ToUserViewModel(IEnumerable<UserModel> users)
        {
            List<UserViewModel> userViewModel = new List<UserViewModel>();
            foreach (var user in users)
            {
                userViewModel.Add(new UserViewModel
                {
                    Id = user.Id,
                    Login = user.Name,
                    Password = user.Password,
                    Email = user.Email
                });
            }
            return userViewModel;
        }
        private UserModel ParseToUserModel(UserViewModel viewModel)
        {
            UserModel userModel = new UserModel
            {
                Id=viewModel.Id,
                Name= viewModel.Login,
                Password=viewModel.Password,
                Email=viewModel.Email
            };
            return userModel;
        }
        private UserViewModel ParseToViewModel(UserModel userModel)
        {
            UserViewModel viewModel = new UserViewModel
            {
                Id=userModel.Id,
                Login = userModel.Name,
                Password = userModel.Password,
                Email = userModel.Email
            };
            return viewModel;
        }
        #endregion
    }
}