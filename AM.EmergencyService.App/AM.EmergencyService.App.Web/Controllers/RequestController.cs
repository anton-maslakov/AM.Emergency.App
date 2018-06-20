using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Data;
using AM.EmergencyService.App.Data.Repository;
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
        private static ILogger _logger;
        private readonly IRepository _repository;

        public RequestController(IRepository repository, ILogger logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public ActionResult Index(string requestDate = "")
        {
            _logger.Log(LogLevel.Info, "RequesPage is running.");
            if (!string.IsNullOrEmpty(requestDate))
            {
                var requestsByDate = (from dataProvider in _repository.Requests
                                      where dataProvider.RequestDate.ToShortDateString().Equals(DateTime.Parse(requestDate).ToShortDateString())
                                      select dataProvider);
                return View(requestsByDate);
            }
            else
            {
                var requestsByDate = _repository.Requests;
                return View(requestsByDate);
            }
        }
        public ActionResult Search(string searchString = "", string filter = "requestNumber")
        {
            if (!string.IsNullOrEmpty(searchString))
            {
                switch (filter)
                {
                    case "requestNumber":
                        {
                            var requestsByNumber = (from dataProvider in _repository.Requests
                                                    where dataProvider.RequestNumber.Equals(int.Parse(searchString))
                                                    select dataProvider);
                            return View(requestsByNumber);
                        }
                    case "requestCategory":
                        {
                            var requestsByCategory = (from dataProvider in _repository.Requests
                                                      where dataProvider.RequestCategory.ToUpper().Contains(searchString.ToUpper())
                                                      select dataProvider);
                            return View(requestsByCategory);
                        }
                    case "requestAddress":
                        {
                            var requestsByAddress = (from dataProvider in _repository.Requests
                                                     where dataProvider.RequestAddress.ToUpper().Contains(searchString.ToUpper())
                                                     select dataProvider);
                            return View(requestsByAddress);
                        }
                }
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}
