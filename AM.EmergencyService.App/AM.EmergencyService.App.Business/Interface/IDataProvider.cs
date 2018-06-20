using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.Interface
{
    public interface IDataProvider
    {
        IDataManipulator<BrigadeModel> Brigades { get; }
        IDataManipulator<RescuerModel> Rescuers { get; }
        IDataManipulator<RequestModel> Requests { get; }
        IDataManipulator<InventoryModel> Inventory { get; }
        IDataManipulator<IncidentModel> Incidents { get; }
    }
}
