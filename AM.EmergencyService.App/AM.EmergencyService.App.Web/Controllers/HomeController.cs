using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class HomeController : Controller
    {
        private static ILogger _logger;
        private IDataProvider _dataProvider;

        public HomeController(IDataProvider dataProvider, ILogger logger)
        {
            _dataProvider = dataProvider;
            _logger = logger;
        }
        public ActionResult Index(string requestDate = "")
        {
            _logger.Log(LogLevel.Info, "Application HomePage is running.");
            if (!string.IsNullOrEmpty(requestDate))
            {
                var requestsByDate = (from dataProvider in _dataProvider.Requests
                                     where dataProvider.RequestDate.ToShortDateString().Equals(DateTime.Parse(requestDate).ToShortDateString())
                                     select dataProvider);
                return View(requestsByDate);
            }
            else
            {
                var requestsByDate = _dataProvider.Requests;
                return View(requestsByDate);
            }
        }
    }
}
