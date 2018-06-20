using AM.EmergencyService.App.Common.Models.Authorization;

namespace AM.EmergencyService.App.Business.Service
{
    public interface IUserService
    {
        void Create(UserModel userModel);
        void Update(UserModel userModel);
        void Delete(int id);

    }
}
