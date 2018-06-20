using System.Collections.Generic;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class BrigadesProvider : IBrigadesProvider
    {
        ILogger _logger;
        IBrigadesRepository _repos;
        public BrigadesProvider(ILogger logger, IBrigadesRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IBrigadesRepository");
            _logger = logger;
            _repos = repos;
        }

        public IEnumerable<BrigadeModel> GetAllData()
        {
            return _repos.GetAllData();
        }
    }
}
