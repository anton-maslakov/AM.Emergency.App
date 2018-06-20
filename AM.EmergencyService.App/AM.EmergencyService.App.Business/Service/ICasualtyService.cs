using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Business.Service
{
    public interface ICasualtyService
    {
        void Create(CasualtyModel casualtyModel);
        void DeleteCasualtyFromRequest(int requestNumber, int casualtyId);

    }
}
