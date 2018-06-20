using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IInventoryRepository
    {
        IEnumerable<InventoryModel> GetInventoryByRequestNumber(int requestNumber);
    }
}
