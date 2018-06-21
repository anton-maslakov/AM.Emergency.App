using System.Collections.Generic;
using AM.EmergencyService.App.Common.Helper;
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
            ErrorHandlingHelper.IfArgumentNullException(logger,"ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "ICasualtyRepository");
            _logger = logger;
            _repos = repos;
        }

        public IEnumerable<CasualtyModel> GetAllCasualty()
        {
            return _repos.GetAllCasualty();
        }

        public CasualtyModel GetCasualtyById(int casualtyId)
        {
            return _repos.GetCasualtyById(casualtyId);
        }

        public IEnumerable<CasualtyModel> GetCasualtyByRequest(int requestNumber)
        {
            return _repos.GetCasualtyByRequest(requestNumber);
        }

        public IEnumerable<CasualtyModel> GetCasualtyNotInRequest(int requestNumber)
        {
            return _repos.GetCasualtyNotInRequest(requestNumber);
        }
    }
}
