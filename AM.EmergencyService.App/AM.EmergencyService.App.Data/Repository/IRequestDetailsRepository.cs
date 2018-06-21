using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRequestDetailsRepository
    {
        RequestDetailModel GetRequestDetailsByRequestNumber(int requestNumber);
        void AddInventoryToRequestDetail(int requestNumber, int inventoryNumber);
        void AddCasualtyToRequestDetail(int requestNumber, int casualtyId);
        void Create(RequestDetailModel requestDetailModel);
        void Update(RequestDetailModel requestDetailModel);
        void Delete(int id);
    }
}
