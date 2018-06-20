using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Models.Authorization;
using AM.EmergencyService.App.Data.Repository;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class UserProvider : IUserProvider
    {
        IUserRepository _repos;
        public UserProvider(IUserRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(repos, "IUserRepository");
            _repos = repos;
        }

        public UserModel GetUserById(int id)
        {
            return _repos.GetUserById(id);
        }

        IEnumerable<UserModel> IUserProvider.GetAllUsers()
        {
            return _repos.GetAllUsers();
        }

        UserModel IUserProvider.GetUserByLogin(string login)
        {
            return _repos.GetUserByLogin(login);
        }

        IEnumerable<RoleModel> IUserProvider.GetUserRoles(int userId)
        {
            return _repos.GetUserRoles(userId);
        }
    }
}
