using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface ICasualtyProvider
    {
        IEnumerable<CasualtyModel> GetCasualtyByRequest(int requestNumber);
        IEnumerable<CasualtyModel> GetCasualtyNotInRequest(int requestNumber);
        IEnumerable<CasualtyModel> GetAllCasualty();
        CasualtyModel GetCasualtyById(int casualtyId);

    }
}
