using AM.EmergencyService.App.Business.Interface;
using System.Linq;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class BrigadeController : Controller
    {
        private IDataProvider _provider;

        public BrigadeController(IDataProvider provider)
        {
            _provider = provider;
        }
        // GET: Brigade
        public ActionResult Index()
        {
            var brigades = _provider.Brigades.GetData("EXEC GetBrigades");
            return View(brigades);
        }

        public ActionResult Details(int id)
        {
            var rescuers = _provider.Rescuers.GetData("EXEC GetBrigadeRescuers @BrigadeId="+id);
            var inventory = _provider.Inventory.GetData("EXEC GetBrigadeInventory @BrigadeId="+id);
            return View(rescuers);
        }
    }
}