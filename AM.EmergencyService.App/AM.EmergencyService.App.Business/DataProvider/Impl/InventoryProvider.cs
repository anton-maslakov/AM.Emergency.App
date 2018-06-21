using System.Collections.Generic;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class InventoryProvider : IInventoryProvider
    {
        ILogger _logger;
        IInventoryRepository _repos;
        public InventoryProvider(ILogger logger, IInventoryRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IInventoryRepository");
            _logger = logger;
            _repos = repos;
        }
        public IEnumerable<InventoryModel> GetAllData()
        {
            return _repos.GetAllData();
        }

        public IEnumerable<InventoryModel> GetInventoryByBrigadeNumber(int brigadeNumber)
        {
            return _repos.GetInventoryByBrigadeNumber(brigadeNumber);
        }

        public InventoryModel GetInventoryByNumber(int inventoryNumber)
        {
            return _repos.GetInventoryByNumber(inventoryNumber);
        }

        public IEnumerable<InventoryModel> GetInventoryByRequestNumber(int requestNumber)
        {
            return _repos.GetInventoryByRequestNumber(requestNumber);
        }

        public IEnumerable<InventoryModel> GetInventoryNotInRequest(int requestNumber)
        {
            return _repos.GetInventoryNotInRequest(requestNumber);
        }
    }
}
