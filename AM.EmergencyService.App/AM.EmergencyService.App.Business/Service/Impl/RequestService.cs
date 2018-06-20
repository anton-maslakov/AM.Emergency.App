using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class RequestService:IRequestService
    {
        private ILogger _logger;
        private IRequestsRepository _repos;
        private ICacheService _cache;

        public RequestService(ILogger logger, IRequestsRepository repos, ICacheService cache)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(cache, "ICacheService");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IRequestsRepository");
            _cache = cache;
            _logger = logger;
            _repos = repos;
        }
        public void Create(RequestModel requestModel)
        {
            IEnumerable<RequestModel> requestList = _cache.Get<IEnumerable<RequestModel>>("requestList");
            if (requestList != null)
            {
                _cache.Delete("requestList");
            }
            _repos.Create(requestModel);
        }

    }
}
