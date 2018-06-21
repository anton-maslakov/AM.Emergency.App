
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models.Authorization;
using AM.EmergencyService.App.Data.Repository;
using Newtonsoft.Json;
using System;
using System.Web;
using System.Web.Security;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class UserLogin : IUserLogin
    {
        IUserRepository _userRepository;
        ILogger _logger;
        public UserLogin(IUserRepository userRepository, ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(userRepository, "IUserRepository");
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _userRepository = userRepository;
            _logger = logger;
        }

        public void LogIn(string login, string password)
        {
            if (IsValidUser(login, password))
            {
                var user = _userRepository.GetUserByLogin(login);
                if (user != null)
                {
                    AddUserToCookies(user);
                }
            }
        }

        public void LogOut()
        {
            FormsAuthentication.SignOut();
        }
        private void AddUserToCookies(UserModel user)
        {
            var UserData = JsonConvert.SerializeObject(user);
            var authTicket = new FormsAuthenticationTicket(1, user.Name, DateTime.Now, DateTime.Now.AddMinutes(5), false, UserData);
            var encryptedTicket = FormsAuthentication.Encrypt(authTicket);
            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            HttpContext.Current.Response.Cookies.Add(cookie);
        }
        private bool IsValidUser(string login, string password)
        {
            if (login == null || password == null)
            {
                return false;
            }
            if (_userRepository.GetAllLogins().Contains(login))
            {
                if (_userRepository.GetUserByLogin(login).Password.Equals(password))
                {
                    return true;
                }
                else
                {
                    _logger.Log(LogLevel.Warn, "Invalid password was input");
                    return false;
                }
            }
            else
            {
                _logger.Log(LogLevel.Warn, "Invalid login input");
                return false;
            }
        }
    }
}
