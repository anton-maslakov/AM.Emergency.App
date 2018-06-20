using AM.EmergencyService.App.Data;
using AM.EmergencyService.App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class BrigadeController : Controller
    {
        private readonly IRepository _repository;

        public BrigadeController(IRepository repository)
        {
            _repository = repository;
        }
        // GET: Brigade
        public ActionResult Index()
        {
            var brigades = _repository.Brigades;
            var rescuers = _repository.Rescuers;
            return View(brigades);
        }

        public ActionResult Details(int id)
        {
            var rescuers = (from dataProvider in _repository.Rescuers
                            where dataProvider.BrigadeNumber.Equals(id)
                            select dataProvider);
            return View(rescuers);
        }
    }
}