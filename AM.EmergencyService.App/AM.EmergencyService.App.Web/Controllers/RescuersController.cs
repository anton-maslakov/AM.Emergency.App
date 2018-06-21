using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Web.Attributes;
using AM.EmergencyService.App.Web.Models.Rescuers;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class RescuersController : Controller
    {
        private IRescuersProvider _rescuersProvider;
        private IRescuersService _rescuerService;
        public RescuersController(IRescuersProvider rescuersProvider, IRescuersService rescuerService)
        {
            ErrorHandlingHelper.IfArgumentNullException(rescuersProvider, "IRescuersProvider");
            ErrorHandlingHelper.IfArgumentNullException(rescuerService, "IRescuersService");
            _rescuerService = rescuerService;
            _rescuersProvider = rescuersProvider;
        }
        // GET: Rescuers
        [Editor]
        public ActionResult Index()
        {
            var rescuersList = _rescuersProvider.GetAllData();
            return View(ToRescuerViewModel(rescuersList));
        }
        [Editor]
        public ActionResult Edit(int rescuerId)
        {
            var rescuerList = _rescuersProvider.GetRescuerById(rescuerId);
            return View(ParseRescuerModelToViewModel(rescuerList));
        }
        [HttpPost]
        public ActionResult Edit(RescuerViewModel rescuerModel)
        {
            _rescuerService.Edit(ParseViewModelToRescuerModel(rescuerModel));
            return RedirectToAction("Index");
        }
        [Editor]
        public ActionResult DeleteRescuerFromBrigade(int brigadeNumber, int rescuerId)
        {
            _rescuerService.DeleteRescuerFromBrigade(brigadeNumber, rescuerId);
            return RedirectToAction("Details", "Brigade", new { brigadeNumber = brigadeNumber });
        }
        public ActionResult Create()
        {
            RescuerCreateViewModel viewModel = new RescuerCreateViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(RescuerCreateViewModel model)
        {
            _rescuerService.Add(ParseToRescuerModel(model));
            return RedirectToAction("Index");
        }
        #region PartialViews
        [ChildActionOnly]
        public PartialViewResult SelectRescuers()
        {
            var rescuerList = ToRescuerSelectViewModel(_rescuersProvider.GetAllData());
            if (rescuerList != null)
            {
                return PartialView(rescuerList);
            }
            else
            {
                return null;
            }
        }
        [ChildActionOnly]
        public PartialViewResult ShowBrigadeRescuers(int brigadeNumber, DateTime date)
        {
            ViewBag.brigadeNumber = brigadeNumber;
            var rescuerList = _rescuersProvider.GetRescuersByBrigadeNumber(brigadeNumber, date);
            if (rescuerList != null)
            {
                return PartialView(rescuerList);
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Helpers
        private List<RescuerSelectViewModel> ToRescuerSelectViewModel(IEnumerable<RescuerModel> rescuers)
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
        private List<RescuerViewModel> ToRescuerViewModel(IEnumerable<RescuerModel> rescuers)
        {
            List<RescuerViewModel> rescuersViewModel = new List<RescuerViewModel>();
            foreach (var rescuer in rescuers)
            {
                rescuersViewModel.Add(new RescuerViewModel
                {
                    Id = rescuer.Id,
                    Firstname = rescuer.Firstname,
                    Surname = rescuer.Surname,
                    Lastname = rescuer.Lastname,
                    BirthDate = rescuer.BirthDate,
                    Job = rescuer.Job
                });
            }
            return rescuersViewModel;
        }

        private RescuerModel ParseToRescuerModel(RescuerCreateViewModel rescuer)
        {
            RescuerModel rescuerModel = new RescuerModel();

            rescuerModel = new RescuerModel
            {
                Firstname = rescuer.Firstname,
                Surname = rescuer.Surname,
                Lastname = rescuer.Lastname,
                BirthDate = rescuer.BirthDate,
                Job = rescuer.Job
            };
            return rescuerModel;
        }
        private RescuerModel ParseViewModelToRescuerModel(RescuerViewModel rescuer)
        {
            RescuerModel rescuerModel = new RescuerModel();

            rescuerModel = new RescuerModel
            {
                Id=rescuer.Id,
                Firstname = rescuer.Firstname,
                Surname = rescuer.Surname,
                Lastname = rescuer.Lastname,
                BirthDate = rescuer.BirthDate,
                Job = rescuer.Job
            };
            return rescuerModel;
        }
        private RescuerViewModel ParseRescuerModelToViewModel(RescuerModel rescuer)
        {
            RescuerViewModel rescuerModel = new RescuerViewModel();

            rescuerModel = new RescuerViewModel
            {
                Id = rescuer.Id,
                Firstname = rescuer.Firstname,
                Surname = rescuer.Surname,
                Lastname = rescuer.Lastname,
                BirthDate = rescuer.BirthDate,
                Job = rescuer.Job
            };
            return rescuerModel;
        }
        #endregion
    }
}