using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class RequestController : Controller
    {
        private static ILogger _logger;
        private IRequestsProvider _requestsProvider;
        private IRequestDetailsProvider _requestDetailsProvider;

        public RequestController(IRequestsProvider requestsProvider, IRequestDetailsProvider requestDetailsProvider, ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(requestsProvider, "IRequestsProvider");
            ErrorHandlingHelper.IfArgumentNullException(requestDetailsProvider, "IRequestDetailsProvider");
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _requestsProvider = requestsProvider;
            _requestDetailsProvider = requestDetailsProvider;
            _logger = logger;
        }

        public ActionResult Index(string requestDate = "")
        {
            _logger.Log(LogLevel.Info, "RequestPage is running.");
            if (!string.IsNullOrEmpty(requestDate))
            {
                var requestsByDate = (from dataProvider in _requestsProvider.GetAllData()
                                      where dataProvider.RequestDate.Equals(DateTime.Parse(requestDate).ToShortDateString())
                                      select dataProvider);
                return View(requestsByDate);
            }
            else
            {
                var requestsByDate = _requestsProvider.GetAllData();
                return View(requestsByDate);
            }
        }
        public ActionResult Search()
        {
            return View();
        }

        public ActionResult Details(int requestNumber)
        {
            var incidents = _requestDetailsProvider.GetRequestDetailsByRequestNumber(requestNumber);
            return View(incidents);
        }
        [HttpGet]
        public ActionResult GetDataSearch(string SearchBy, string SearchValue)
        {
            IEnumerable<RequestViewModel> requestList = new List<RequestViewModel>();
            if (!string.IsNullOrEmpty(SearchValue))
            {
                switch (SearchBy)
                {
                    case "requestNumber":
                        {
                            requestList = ParseRequestListToViewModelList(_requestsProvider.GetRequestByNumber(Int32.Parse(SearchValue)));
                            break;
                        }
                    case "requestCategory":
                        {
                            requestList = ParseRequestListToViewModelList(_requestsProvider.GetRequestByCategory(SearchValue));
                            break;
                        }
                    case "requestAddress":
                        {
                            requestList = requestList = ParseRequestListToViewModelList(_requestsProvider.GetRequestByAddress(SearchValue));
                            break;
                        }
                }
            }
            else
            {
                return View();
            }
            return PartialView("_searchPartialView", requestList);
        }

        private List<RequestViewModel> ParseRequestListToViewModelList(IEnumerable<RequestModel> requestList)
        {
            List<RequestViewModel> requestViewModelList = new List<RequestViewModel>();
            foreach (RequestModel request in requestList)
            {
                requestViewModelList.Add(new RequestViewModel
                {
                    RequestNumber = request.RequestNumber,
                    RequestAddress = request.RequestAddress,
                    RequestDate = request.RequestDate,
                    RequestReason = request.RequestReason,
                    CategoryName = request.CategoryName
                });
            }
            return requestViewModelList;
        }
    }
}
