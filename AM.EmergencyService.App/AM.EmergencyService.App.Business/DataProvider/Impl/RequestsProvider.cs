using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class RequestsProvider : IRequestsProvider
    {
        private IRequestsRepository _repos;
        private ICacheService _cache;
        public RequestsProvider(IRequestsRepository repos, ICacheService cache)
        {
            ErrorHandlingHelper.IfArgumentNullException(repos, "IRequestsRepository");
            ErrorHandlingHelper.IfArgumentNullException(cache, "ICacheService");
            _repos = repos;
            _cache = cache;
        }
        public IEnumerable<RequestModel> GetAllData()
        {
            IEnumerable<RequestModel> requestList = _cache.Get<IEnumerable<RequestModel>>("requestList");

            if (requestList == null)
            {
                requestList = _repos.GetAllData();
                _cache.Add("requestList", requestList, 2000);

            }
            return requestList;
        }

        public IEnumerable<RequestModel> GetRequestByAddress(string requestAddress, string requestDate)
        {
            if (String.IsNullOrEmpty(requestDate))
            {
                return _repos.GetRequestByAddress(requestAddress);
            }
            else
            {
                return _repos.GetRequestByAddressAndDate(requestAddress, requestDate);
            }
        }

        public IEnumerable<RequestModel> GetRequestByCategory(string requestCategory, string requestDate)
        {
            if (String.IsNullOrEmpty(requestDate))
            {
                return _repos.GetRequestByCategory(requestCategory);
            }
            else
            {
                return _repos.GetRequestByCategoryAndDate(requestCategory, requestDate);
            }
        }

        public IEnumerable<RequestModel> GetRequestByNumber(int requestNumber, string requestDate)
        {
            if (requestNumber < 1)
            {
                throw new ArgumentException("Номер запроса указан неверно. Пожалуйста введите значение больше 1");
            }
            else
            {
                if (String.IsNullOrEmpty(requestDate))
                {
                    return _repos.GetRequestByNumber(requestNumber);
                }
                else
                {
                    return _repos.GetRequestByNumberAndDate(requestNumber, requestDate);
                }
            }
        }
    }
}
