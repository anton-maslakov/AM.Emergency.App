using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface ICasualtyRepository
    {
        IEnumerable<CasualtyModel> GetCasualtyByRequest(int requestNumber);
        CasualtyModel GetCasualtyById(int casualtyId);
        IEnumerable<CasualtyModel> GetCasualtyNotInRequest(int requestNumber);
        IEnumerable<CasualtyModel> GetAllCasualty();
        void DeleteCasualtyFromRequest(int requestNumber, int casualtyId);
        void Create(CasualtyModel casualtyModel);
        void Edit(CasualtyModel casualtyModel);
    }
}
