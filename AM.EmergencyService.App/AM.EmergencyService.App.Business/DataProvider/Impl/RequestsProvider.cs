using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class RequestsProvider : IRequestsProvider
    {
        private Logger _logger;
        private IRequestsRepository _repos;
        public RequestsProvider(Logger logger, IRequestsRepository repos)
        {
            _logger = logger;
            _repos = repos;
        }
        public IEnumerable<RequestModel> GetAllData()
        {
            return _repos.GetAllData();
        }
    }
}
