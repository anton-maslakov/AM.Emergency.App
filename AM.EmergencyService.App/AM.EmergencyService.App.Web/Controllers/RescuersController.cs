using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Web.Attributes;
using AM.EmergencyService.App.Web.Models.Rescuers;
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
            return View(rescuersList);
        }
        [Editor]
        public ActionResult Edit(int rescuerId)
        {
            var rescuerList = _rescuersProvider.GetRescuerById(rescuerId);
            return View(rescuerList);
        }
        [HttpPost]
        public ActionResult Edit(RescuerModel rescuerModel)
        {
            _rescuerService.Edit(rescuerModel);
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
            var rescuerList = ToRescuerViewModel(_rescuersProvider.GetAllData());
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
        public PartialViewResult ShowBrigadeRescuers(int brigadeNumber)
        {
            ViewBag.brigadeNumber = brigadeNumber;
            var rescuerList = _rescuersProvider.GetRescuersByBrigadeNumber(brigadeNumber);
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
        #endregion
    }
}