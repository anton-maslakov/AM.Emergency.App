using AM.EmergencyService.App.Business.DataProvider;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class IncidentController : Controller
    {
        private IRequestDetailsProvider _requestDetailsProvider; 

        public IncidentController(IRequestDetailsProvider requestDetailsProvider)
        {
            _requestDetailsProvider = requestDetailsProvider;
        }
        public ActionResult IncidentInfo(int id)
        {
            _requestDetailsProvider.GetRequestDetailsByRequestNumber(id);
            return View();
        }
    }
}