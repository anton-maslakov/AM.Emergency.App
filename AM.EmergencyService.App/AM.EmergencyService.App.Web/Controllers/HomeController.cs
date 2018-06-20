using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class HomeController : Controller
    {
        private static ILogger _logger;

        public HomeController(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
        }
        public ActionResult Index(string requestDate = "")
        {
            _logger.Log(LogLevel.Info, "Application HomePage is running.");
                return View();
        }
    }
}
