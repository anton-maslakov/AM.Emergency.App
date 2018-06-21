using AM.EmergencyService.App.Common.Models.Authorization;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IUserRepository
    {
        UserModel GetUserByLogin(string login);
        UserModel GetUserById(int id);
        List<string> GetAllLogins();
        IEnumerable<RoleModel> GetUserRoles(int userId);
        IEnumerable<UserModel> GetAllUsers();
        void Create(UserModel userModel);
        void AddUserRole(int userId, int roleId);
        void Update(UserModel userModel);
        void Delete(int id);
    }
}
