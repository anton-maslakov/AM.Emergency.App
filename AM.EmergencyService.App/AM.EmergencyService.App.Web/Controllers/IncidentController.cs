using AM.EmergencyService.App.Business.Interface;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class IncidentController : Controller
    {
        private IDataProvider _provider; 

        public IncidentController(IDataProvider provider)
        {
            _provider = provider;
        }
        public ActionResult IncidentInfo(int id)
        {
            _provider.Incidents.GetData("EXEC GetIncident @RequestId=" + id);
            return View();
        }
    }
}