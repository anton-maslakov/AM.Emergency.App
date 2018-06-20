using System.Collections.Generic;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class RequestDetailsProvider : IRequestDetailsProvider
    {
        ILogger _logger;
        IRequestDetailsRepository _repos;

        public RequestDetailsProvider(ILogger logger, IRequestDetailsRepository repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public IEnumerable<RequestDetailModel> GetRequestDetailsByRequestNumber(int requestNumber)
        {
            return _repos.GetRequestDetailsByRequestNumber(requestNumber);
        }
    }
}
