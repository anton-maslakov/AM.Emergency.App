using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Web.Attributes;
using AM.EmergencyService.App.Web.Models.Brigade;
using AM.EmergencyService.App.Web.Models.Rescuers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class BrigadeController : Controller
    {
        private IBrigadesProvider _brigadesProvider;
        private IBrigadeService _brigadeService;
        private IRescuersProvider _rescuersProvider;
        private IInventoryProvider _inventoryProvider;

        public BrigadeController(IBrigadesProvider brigadesProvider, IBrigadeService brigadeService, IRescuersProvider rescuersProvider, IInventoryProvider inventoryProvider)
        {
            ErrorHandlingHelper.IfArgumentNullException(brigadesProvider, "IBrigadesProvider");
            ErrorHandlingHelper.IfArgumentNullException(rescuersProvider, "IRescuersProvider");
            ErrorHandlingHelper.IfArgumentNullException(inventoryProvider, "IInventoryProvider");
            ErrorHandlingHelper.IfArgumentNullException(brigadeService, "IBrigadeService");
            _brigadeService = brigadeService;
            _brigadesProvider = brigadesProvider;
            _rescuersProvider = rescuersProvider;
            _inventoryProvider = inventoryProvider;
        }
        [Editor]
        public ActionResult Index()
        {
            var brigades = _brigadesProvider.GetBrigadeByDate(DateTime.Now);
            return View(brigades);
        }
        [Dispatcher]
        public ActionResult Details(int brigadeNumber)
        {
            var ViewModel = new BrigadeCreateViewModel
            {
                BrigadeNumber=brigadeNumber,
                InventoryNumber = new List<int>(),
                RescuerId = new List<int>()
            };
            return View(ViewModel);
        }
        [Editor]
        public ActionResult Create()
        {
            var ViewModel = new BrigadeCreateViewModel
            {
                InventoryNumber = new List<int>(),
                RescuerId = new List<int>()
            };
            return View(ViewModel);
        }
        [HttpPost]
        public ActionResult Create(BrigadeCreateViewModel brigadeCreateViewModel)
        {
            if (brigadeCreateViewModel.RescuerId != null)
            {
                foreach (var rescuer in brigadeCreateViewModel.RescuerId)
                {
                    _brigadeService.AddRescuersBrigade(brigadeCreateViewModel.BrigadeNumber, rescuer);
                }
            }
            if (brigadeCreateViewModel.InventoryNumber != null)
            {
                foreach (var inventory in brigadeCreateViewModel.InventoryNumber)
                {
                    _brigadeService.AddInventoryBrigade(brigadeCreateViewModel.BrigadeNumber, inventory);
                }
            }
            return RedirectToAction("Index");
        }
        [Editor]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(BrigadeModel brigadeModel)
        {
            _brigadeService.Add(brigadeModel);
            return RedirectToAction("Index");
        }
        [Editor]
        public ActionResult Edit(int brigadeNumber)
        {
            var ViewModel = new BrigadeCreateViewModel
            {
                BrigadeNumber=brigadeNumber,
                InventoryNumber = new List<int>(),
                RescuerId = new List<int>()
            };
            return View(ViewModel);
        }
       
        #region PartialView
        public PartialViewResult SelectBrigade()
        {
            var brigadeList = _brigadesProvider.GetAllData();
            if (brigadeList != null)
            {
                return PartialView(brigadeList);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Helpers
        private List<RescuerSelectViewModel> ToRescuerViewModel(IEnumerable<RescuerModel> rescuers)
        {
            List<RescuerSelectViewModel> rescuersViewModel = new List<RescuerSelectViewModel>();
            foreach (var rescuer in rescuers)
            {
                rescuersViewModel.Add(new RescuerSelectViewModel
                {
                    Id = rescuer.Id,
                    Name = rescuer.Job + " " + rescuer.Surname + " " + rescuer.Firstname + " " + rescuer.Lastname
                });
            }
            return rescuersViewModel;
        }
        #endregion
    }
}