using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Business.Service
{
    public interface IRescuersService
    {
        void DeleteRescuerFromBrigade(int brigadeNumber, int rescuerId);
        void Add(RescuerModel rescuerModel);
        void Edit(RescuerModel rescuerModel);

    }
}
