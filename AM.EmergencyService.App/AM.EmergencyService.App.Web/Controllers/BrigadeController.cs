using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Common.Helper;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class BrigadeController : Controller
    {
        private IBrigadesProvider _brigadesProvider;
        private IRescuersProvider _rescuersProvider;

        public BrigadeController(IBrigadesProvider brigadesProvider, IRescuersProvider rescuersProvider)
        {
            ErrorHandlingHelper.IfArgumentNullException(brigadesProvider, "IBrigadesProvider");
            ErrorHandlingHelper.IfArgumentNullException(rescuersProvider, "IRescuersProvider");
            _brigadesProvider = brigadesProvider;
            _rescuersProvider = rescuersProvider;
        }
        // GET: Brigade
        public ActionResult Index()
        {
            var brigades = _brigadesProvider.GetAllData();
            return View(brigades);
        }

        public ActionResult Details(int brigadeNumber)
        {
            var rescuers = _rescuersProvider.GetRescuersByBrigadeNumber(brigadeNumber);
            return View(rescuers);
        }
    }
}