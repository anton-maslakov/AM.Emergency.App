using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface ICasualtyRepository
    {
        IEnumerable<CasualtyModel> GetCasualtyByRequest(int requestNumber);
        IEnumerable<CasualtyModel> GetCasualtyNotInRequest(int requestNumber);
        IEnumerable<CasualtyModel> GetAllCasualty();
        void DeleteCasualtyFromRequest(int requestNumber, int casualtyId);
        void Create(CasualtyModel casualtyModel);
        void Update(CasualtyModel casualtyModel);
    }
}
