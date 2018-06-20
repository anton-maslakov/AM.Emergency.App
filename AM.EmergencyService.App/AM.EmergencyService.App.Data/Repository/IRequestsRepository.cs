using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRequestsRepository
    {
        IEnumerable<RequestModel> GetAllData();
        IEnumerable<RequestModel> GetRequestByNumber(int requestNumber);
        IEnumerable<RequestModel> GetRequestByAddress(string requestAddress);
        IEnumerable<RequestModel> GetRequestByCategory(string requestCategory);
    }
}
