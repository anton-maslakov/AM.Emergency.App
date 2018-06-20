using AM.EmergencyService.App.Business.Interface;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Data.Repository;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class RequestController : Controller
    {
        private static ILogger _logger;
        private readonly IDataProvider _provider;

        public RequestController(IDataProvider provider, ILogger logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public ActionResult Index(string requestDate = "")
        {
            _logger.Log(LogLevel.Info, "RequestPage is running.");
            if (!string.IsNullOrEmpty(requestDate))
            {
                var requestsByDate = (from dataProvider in _provider.Requests.GetData("EXEC GetRequests")
                                      where dataProvider.RequestDate.ToShortDateString().Equals(DateTime.Parse(requestDate).ToShortDateString())
                                      select dataProvider);
                return View(requestsByDate);
            }
            else
            {
                var requestsByDate = _provider.Requests.GetData("EXEC GetRequests");
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
                            var requestsByNumber = (from dataProvider in _provider.Requests.GetData("EXEC GetRequests")
                                                    where dataProvider.RequestNumber.Equals(int.Parse(searchString))
                                                    select dataProvider);
                            return View(requestsByNumber);
                        }
                    case "requestCategory":
                        {
                            var requestsByCategory = (from dataProvider in _provider.Requests.GetData("EXEC GetRequests")
                                                      where dataProvider.RequestCategory.ToUpper().Contains(searchString.ToUpper())
                                                      select dataProvider);
                            return View(requestsByCategory);
                        }
                    case "requestAddress":
                        {
                            var requestsByAddress = (from dataProvider in _provider.Requests.GetData("EXEC GetRequests")
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

        public ActionResult Details(int id)
        {
            var incidents = _provider.Incidents.GetData("EXEC GetIncident @RequestId=" + id);
            return View(incidents);
        }
    }
}
