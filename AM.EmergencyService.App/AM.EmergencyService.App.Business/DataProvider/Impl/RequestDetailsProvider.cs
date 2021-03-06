﻿using System.Collections.Generic;
using AM.EmergencyService.App.Common.Helper;
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
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IRequestDetailsRepository");
            _logger = logger;
            _repos = repos;
        }

        public RequestDetailModel GetRequestDetailsByRequestNumber(int requestNumber)
        {
            return _repos.GetRequestDetailsByRequestNumber(requestNumber);
        }
    }
}
