using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class RequestsProvider : IRequestsProvider
    {
        private ILogger _logger;
        private IRequestsRepository _repos;
        public RequestsProvider(ILogger logger, IRequestsRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IRequestsRepository");
            _logger = logger;
            _repos = repos;
        }
        public IEnumerable<RequestModel> GetAllData()
        {
            return _repos.GetAllData();
        }

        public IEnumerable<RequestModel> GetRequestByAddress(string requestAddress)
        {
            return _repos.GetRequestByAddress(requestAddress);
        }

        public IEnumerable<RequestModel> GetRequestByCategory(string requestCategory)
        {
            return _repos.GetRequestByCategory(requestCategory);
        }

        IEnumerable<RequestModel> IRequestsProvider.GetRequestByNumber(int requestNumber)
        {
            return _repos.GetRequestByNumber(requestNumber);
        }
    }
}
