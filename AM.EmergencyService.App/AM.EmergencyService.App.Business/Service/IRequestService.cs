using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Business.Service
{
    public interface IRequestService
    {
        void Create(RequestModel requestModel);
        void Update(RequestModel requestModel);
    }
}
