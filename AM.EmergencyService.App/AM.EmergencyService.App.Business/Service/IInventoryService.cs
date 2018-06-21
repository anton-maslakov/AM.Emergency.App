using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Business.Service
{
    public interface IInventoryService
    {
        void DeleteInventoryFromBrigade(int brigadeNumber, int inventoryNumber);
        void DeleteInventoryFromRequest(int requestNumber, int inventoryNumber);
        void Edit(InventoryModel inventoryModel);
        void Create(InventoryModel inventoryModel);
    }
}
