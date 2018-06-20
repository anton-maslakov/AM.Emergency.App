using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRequestDetailsRepository
    {
        IEnumerable<RequestDetailModel> GetRequestDetailsByRequestNumber(int requestNumber);
    }
}
