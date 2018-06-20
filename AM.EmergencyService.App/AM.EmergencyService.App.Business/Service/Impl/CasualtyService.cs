using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class CasualtyService:ICasualtyService
    {
        ILogger _logger;
        ICasualtyRepository _repos;
        public CasualtyService(ILogger logger, ICasualtyRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "ICasualtyRepository");
            _logger = logger;
            _repos = repos;
        }
        public void Create(CasualtyModel casualtyModel)
        {
            _repos.Create(casualtyModel);
        }

        public void DeleteCasualtyFromRequest(int requestNumber, int casualtyId)
        {
            _repos.DeleteCasualtyFromRequest(requestNumber, casualtyId);
        }

    }
}
