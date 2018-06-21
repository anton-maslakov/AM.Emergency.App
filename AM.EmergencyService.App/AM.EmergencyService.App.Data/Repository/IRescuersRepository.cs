using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRescuersRepository
    {
        IEnumerable<RescuerModel> GetAllData();
        IEnumerable<RescuerModel> GetRescuersByBrigadeNumber(int brigadeNumber);
        RescuerModel GetRescuerById(int rescuerId);
        void Create(RescuerModel rescuerModel);
        void Edit(RescuerModel rescuerModel);
        void Delete(int id);
        void DeleteRescuerFromBrigade(int brigadeNumber, int rescuerId);
        IEnumerable<RescuerModel> GetRescuersNotInBrigade();
    }
}
