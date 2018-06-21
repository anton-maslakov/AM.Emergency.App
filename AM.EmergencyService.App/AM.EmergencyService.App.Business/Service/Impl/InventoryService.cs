using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class InventoryService:IInventoryService
    {
        ILogger _logger;
        IInventoryRepository _repos;
        public InventoryService(ILogger logger, IInventoryRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IInventoryRepository");
            _logger = logger;
            _repos = repos;
        }

        public void Create(InventoryModel inventoryModel)
        {
            _repos.Create(inventoryModel);
        }

        public void DeleteInventoryFromBrigade(int brigadeNumber, int inventoryNumber)
        {
            _repos.DeleteInventoryFromBrigade(brigadeNumber, inventoryNumber);
        }

        public void DeleteInventoryFromRequest(int requestNumber, int inventoryNumber)
        {
            _repos.DeleteInventoryFromRequest(requestNumber, inventoryNumber);
        }

        public void Edit(InventoryModel inventoryModel)
        {
            _repos.Edit(inventoryModel);
        }
    }
}
