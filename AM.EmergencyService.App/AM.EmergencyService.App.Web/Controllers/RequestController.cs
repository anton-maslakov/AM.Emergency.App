using AM.EmergencyService.App.Web.Providers;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class RequestController : Controller
    {
        private readonly IDataProvider _dataProvider;

        public RequestController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }

        // GET: Request
        public ActionResult Index()
        {
            var requests = _dataProvider.GetData();

            return View(requests);
        }
    }
}
