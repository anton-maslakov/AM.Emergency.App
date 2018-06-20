using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Data;
using AM.EmergencyService.App.Data.Repository;
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
        private IRepository _repository;

        public HomeController(IRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }
        public ActionResult Index(string requestDate = "")
        {
            _logger.Log(LogLevel.Info, "Application HomePage is running.");
                return View();
        }
    }
}
