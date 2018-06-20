using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using System;
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
        public ActionResult Search(string searchString = "", string filter = "requestNumber")
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                switch (filter)
                {
                    case "requestNumber":
                        {
                            var requestsByNumber = (from dataProvider in _requestsProvider.GetAllData()
                                                    where dataProvider.RequestNumber.Equals(int.Parse(searchString))
                                                    select dataProvider);
                            return View(requestsByNumber);
                        }
                    case "requestCategory":
                        {
                            var requestsByCategory = (from dataProvider in _requestsProvider.GetAllData()
                                                      where dataProvider.CategoryName.ToUpper().Contains(searchString.ToUpper())
                                                      select dataProvider);
                            return View(requestsByCategory);
                        }
                    case "requestAddress":
                        {
                            var requestsByAddress = (from dataProvider in _requestsProvider.GetAllData()
                                                     where dataProvider.RequestAddress.ToUpper().Contains(searchString.ToUpper())
                                                     select dataProvider);
                            return View(requestsByAddress);
                        }
                }
            }
            else
            {
                return View();
            }
            return View();
        }

        public ActionResult Details(int requestNumber)
        {
            var incidents = _requestDetailsProvider.GetRequestDetailsByRequestNumber(requestNumber);
            return View(incidents);
        }
    }
}
