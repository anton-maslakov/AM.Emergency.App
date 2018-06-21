using AM.EmergencyService.App.Common.Models.Authorization;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IUserProvider
    {
        UserModel GetUserByLogin(string login);
        UserModel GetUserById(int id);
        IEnumerable<RoleModel> GetUserRoles(int userId);
        IEnumerable<UserModel> GetAllUsers();
    }
}
