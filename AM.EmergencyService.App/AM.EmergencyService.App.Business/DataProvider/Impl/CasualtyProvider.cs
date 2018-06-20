using System.Collections.Generic;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class CasualtyProvider : ICasualtyProvider
    {
        ILogger _logger;
        ICasualtyRepository _repos;
        public CasualtyProvider(ILogger logger, ICasualtyRepository repos)
        {
            _logger = logger;
            _repos = repos;
        }

        public IEnumerable<CasualtyModel> GetCasualtyByRequest(int requestNumber)
        {
            return _repos.GetCasualtyByRequest(requestNumber);
        }
    }
}
