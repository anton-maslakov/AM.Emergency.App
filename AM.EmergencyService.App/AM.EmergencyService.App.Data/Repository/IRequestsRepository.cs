using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRequestsRepository
    {
        IEnumerable<RequestModel> GetAllData();
    }
}
