using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using System.Web.Mvc;

namespace LogerError.Controllers
{
    public class ErrorController : Controller
    {
        private readonly ILogger _logger;

        public ErrorController(ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _logger = logger;
        }
        public ActionResult NotFound()
        {
            Response.StatusCode = 404;
            _logger.Log(LogLevel.Error, "HTTP 404 error occurred");
            return View();
        }
        public ActionResult InternalServerError()
        {
            Response.StatusCode = 500;
            _logger.Log(LogLevel.Error, "HTTP 500 error occurred");
            return View();
        }
    }
}
