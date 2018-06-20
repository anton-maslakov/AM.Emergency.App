using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IRequestDetailsProvider
    {
        IEnumerable<RequestDetailModel> GetRequestDetailsByRequestNumber(int requestNumber);
    }
}
