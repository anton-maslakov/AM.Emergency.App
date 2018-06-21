using System;
using System.Collections.Generic;
using AM.EmergencyService.App.Business.Service;
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
        ICacheService _cache;
        public BrigadesProvider(ILogger logger, IBrigadesRepository repos, ICacheService cache)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IBrigadesRepository");
            ErrorHandlingHelper.IfArgumentNullException(cache, "ICacheService");
            _logger = logger;
            _repos = repos;
            _cache = cache;
        }

        public IEnumerable<BrigadeModel> GetAllData()
        {
            IEnumerable<BrigadeModel> brigadeList=_cache.Get<IEnumerable<BrigadeModel>>("brigadeList");
            
            if (brigadeList==null)
            {
                brigadeList = _repos.GetAllData();
                _cache.Add<IEnumerable<BrigadeModel>>("brigadeList", brigadeList, 20);
            }
            return brigadeList;
        }

        public IEnumerable<BrigadeModel> GetBrigadeByDate(DateTime date)
        {
            IEnumerable<BrigadeModel> brigadeList = _cache.Get<IEnumerable<BrigadeModel>>("brigadeList");

            if (brigadeList == null)
            {
                brigadeList = _repos.GetBrigadeByDate(date);
                _cache.Add<IEnumerable<BrigadeModel>>("brigadeListbyDate", brigadeList, 20);
            }
            return brigadeList;
        }
    }
}
