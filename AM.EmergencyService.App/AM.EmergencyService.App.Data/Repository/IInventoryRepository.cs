using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IInventoryRepository
    {
        IEnumerable<InventoryModel> GetInventoryByRequestNumber(int requestNumber);
        IEnumerable<InventoryModel> GetInventoryNotInRequest(int requestNumber);
        IEnumerable<InventoryModel> GetAllData();
        InventoryModel GetInventoryByNumber(int brigadeNumber);
        void DeleteInventoryFromRequest(int requestNumber, int inventoryNumber);
        void Create(InventoryModel inventoryModel);
        void Edit(InventoryModel inventoryModel);
        void Delete(int id);
        void DeleteInventoryFromBrigade(int brigadeNumber, int inventoryNumber);
        IEnumerable<InventoryModel> GetInventoryByBrigadeNumber(int brigadeNumber);
    }
}
