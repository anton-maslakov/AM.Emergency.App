using System.Collections.Generic;
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
            _logger = logger;
            _repos = repos;
        }

        public IEnumerable<InventoryModel> GetInventoryByRequestNumber(int requestNumber)
        {
            return _repos.GetInventoryByRequestNumber(requestNumber);
        }
    }
}
