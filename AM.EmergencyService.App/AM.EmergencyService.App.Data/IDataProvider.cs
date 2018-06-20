using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Data
{
    public interface IDataProvider
    {
        ICollection<BrigadeModel> Brigades { get; }
        ICollection<RequestModel> Requests { get; }
        ICollection<RescuerModel> Rescuers { get; }
    }
}
