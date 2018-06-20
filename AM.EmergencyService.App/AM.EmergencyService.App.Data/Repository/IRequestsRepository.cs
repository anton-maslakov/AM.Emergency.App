using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IRequestsRepository
    {
        IEnumerable<RequestModel> GetAllData();
        IEnumerable<RequestModel> GetRequestByAddress(string requestAddress);
        IEnumerable<RequestModel> GetRequestByCategory(string requestCategory);
        IEnumerable<RequestModel> GetRequestByNumber(int requestNumber);
        IEnumerable<RequestModel> GetRequestByAddressAndDate(string requestAddress, string requestDate);
        IEnumerable<RequestModel> GetRequestByCategoryAndDate(string requestCategory, string requestDate);
        IEnumerable<RequestModel> GetRequestByNumberAndDate(int requestNumber, string requestDate);
        void Create(RequestModel requestModel);
        void Update(RequestModel requestModel);
        void Delete(int id);
    }
}
