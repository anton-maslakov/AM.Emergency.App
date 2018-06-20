using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Business.Service
{
    public interface IRequestDetailService
    {
        void AddInventoryToRequestDetail(int requestNumber, int inventoryNumber);
        void AddCasualtyToRequestDetail(int requestNumber, int casualtyId);
        void Create(RequestDetailModel requestDetailModel);

    }
}
