using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IRequestsProvider
    {
        IEnumerable<RequestModel> GetAllData();
        IEnumerable<RequestModel> GetRequestByNumber(int requestNumber, string requestDate);
        IEnumerable<RequestModel> GetRequestByAddress(string requestAddress, string requestDate);
        IEnumerable<RequestModel> GetRequestByCategory(string requestCategory, string requestDate);
    }
}
