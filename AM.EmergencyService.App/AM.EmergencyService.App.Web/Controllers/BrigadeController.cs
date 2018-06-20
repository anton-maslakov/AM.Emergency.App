using AM.EmergencyService.App.Web.Models;
using AM.EmergencyService.App.Web.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class BrigadeController : Controller
    {
        private readonly IDataProvider _dataProvider;

        public BrigadeController(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
        }
        // GET: Brigade
        public ActionResult Index()
        {
            var requests = _dataProvider.GetData();
            return View(requests);
        }
    }
}