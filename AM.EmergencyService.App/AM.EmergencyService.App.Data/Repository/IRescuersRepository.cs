using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRescuersRepository
    {
        IEnumerable<RescuerModel> GetAllData();
        IEnumerable<RescuerModel> GetRescuersByBrigadeNumber(int brigadeNumber);
    }
}
