using AM.EmergencyService.App.Data;
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
            var brigades = _dataProvider.Brigades;
            var rescuers = _dataProvider.Rescuers;
            return View(brigades);
        }

        public ActionResult Details(int id)
        {
            var rescuers = (from dataProvider in _dataProvider.Rescuers
                            where dataProvider.BrigadeNumber.Equals(id)
                            select dataProvider);
            return View(rescuers);
        }
    }
}