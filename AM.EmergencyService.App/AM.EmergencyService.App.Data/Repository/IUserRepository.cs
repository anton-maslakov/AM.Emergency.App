using AM.EmergencyService.App.Common.Models.Authorization;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IUserRepository
    {
        UserModel GetUserByLogin(string login);
        IEnumerable<RoleModel> GetUserRoles(int userId);
        IEnumerable<string> GetAllLogins();
    }
}
