using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRepository
    {
        IDataManipulator<BrigadeModel> Brigades { get; }
        IDataManipulator<RequestModel> Requests { get; }
        IDataManipulator<RescuerModel> Rescuers { get; }
        IDataManipulator<InventoryModel> Inventory { get; }
        IDataManipulator<IncidentModel> Incidents { get; }
    }
}
