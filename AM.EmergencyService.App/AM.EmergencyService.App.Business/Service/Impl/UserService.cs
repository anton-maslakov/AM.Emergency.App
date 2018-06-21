using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Models.Authorization;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class UserService : IUserService
    {
        IUserRepository _repos;

        public UserService(IUserRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(repos, "IUserRepository");
            _repos = repos;
        }

        public void AddUserRoles(int userId, int roleId)
        {
            _repos.AddUserRole(userId,roleId);
        }

        public void Create(UserModel userModel)
        {
            _repos.Create(userModel);
        }

        public void Delete(int id)
        {
            _repos.Delete(id);
        }

        public void Update(UserModel userModel)
        {
            _repos.Update(userModel);
        }
    }
}
