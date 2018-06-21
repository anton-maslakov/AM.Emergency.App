using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class BrigadeService : IBrigadeService
    {
        ILogger _logger;
        IBrigadesRepository _repos;
        ICacheService _cache;
        public BrigadeService(ILogger logger, IBrigadesRepository repos, ICacheService cache)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(cache, "ICacheService");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IBrigadesRepository");
            _cache = cache;
            _logger = logger;
            _repos = repos;
        }
        public void Add(BrigadeModel brigadeModel)
        {

            _repos.Add(brigadeModel);
        }

        public void AddInventoryBrigade(int brigadeNumber, int inventoryNumber)
        {
            IEnumerable<BrigadeModel> brigadeList = _cache.Get<IEnumerable<BrigadeModel>>("brigadeList");
            if (brigadeList != null)
            {
                _cache.Delete("brigadeList");
            }
            _repos.AddInventoryBrigade(brigadeNumber, inventoryNumber);
        }

        public void AddRescuersBrigade(int brigadeNumber, int rescuerId)
        {
            _repos.AddRescuersBrigade(brigadeNumber, rescuerId);
        }
    }
}