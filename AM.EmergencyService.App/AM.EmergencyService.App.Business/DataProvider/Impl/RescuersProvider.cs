using System.Collections.Generic;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class RescuersProvider : IRescuersProvider
    {
        private ILogger _logger;
        private IRescuersRepository _repos;
        public RescuersProvider(ILogger logger, IRescuersRepository repos)
        {
            _logger = logger;
            _repos = repos;
        }
        public IEnumerable<RescuerModel> GetAllData()
        {
            return _repos.GetAllData();
        }

        public IEnumerable<RescuerModel> GetRescuersByBrigadeNumber(int brigadeNumber)
        {
            return _repos.GetRescuersByBrigadeNumber(brigadeNumber);
        }
    }
}
