using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Web.Attributes;
using AM.EmergencyService.App.Web.Models.Casualty;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class CasualtyController : Controller
    {
        private ICasualtyProvider _casualtyProvider;
        private ICasualtyService _casualtyService;

        public CasualtyController(ICasualtyProvider casualtyProvider, ICasualtyService casualtyService)
        {
            ErrorHandlingHelper.IfArgumentNullException(casualtyProvider, "ICasualtyProvider");
            ErrorHandlingHelper.IfArgumentNullException(casualtyService, "ICasualtyService");
            _casualtyProvider = casualtyProvider;
            _casualtyService = casualtyService;
        }
        [Dispatcher]
        public ActionResult DeleteCasualtyFromRequest(int requestNumber, int casualtyId)
        {
            _casualtyService.DeleteCasualtyFromRequest(requestNumber, casualtyId);
            return RedirectToAction("Details", "RequestDetail", new { requestNumber = requestNumber });
        }
        [Editor]
        public ActionResult Index()
        {
            var casualtyList = _casualtyProvider.GetAllCasualty();
            return View(casualtyList);
        }
        [Editor]
        public ActionResult Create()
        {
            CasualtyCreatViewModel viewModel = new CasualtyCreatViewModel();
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(CasualtyCreatViewModel creatViewModel)
        {
            _casualtyService.Create(ParseCreateViewModelToCasualtyModel(creatViewModel));
            return RedirectToAction("Index");
        }
        [Dispatcher]
        public ActionResult Edit(int casualtyId)
        {
            var casualty = _casualtyProvider.GetCasualtyById(casualtyId);
            return View(casualty);
        }
        [HttpPost]
        public ActionResult Edit(CasualtyModel casualty)
        {
            _casualtyService.Edit(casualty);
            return RedirectToAction("Index");
        }

        #region PartialViews
        [ChildActionOnly]
        public PartialViewResult SelectCasualty(int requestNumber)
        {
            var casualtyList = ToCasualtyViewModel(_casualtyProvider.GetCasualtyNotInRequest(requestNumber));
            if (casualtyList != null)
            {
                return PartialView(casualtyList);
            }
            else
            {
                return null;
            }
        }
        [ChildActionOnly]
        public PartialViewResult ShowRequestCasualty(int requestNumber)
        {
            ViewBag.requestNumber = requestNumber;
            var casualtyList = _casualtyProvider.GetCasualtyByRequest(requestNumber);
            if (casualtyList != null)
            {
                return PartialView(casualtyList);
            }
            else
            {
                return null;
            }
        }
        #endregion
        
        #region Helper
        private List<CasualtyViewModel> ToCasualtyViewModel(IEnumerable<CasualtyModel> casualties)
        {
            List<CasualtyViewModel> casualtyViewModel = new List<CasualtyViewModel>();
            foreach (var casyalty in casualties)
            {
                casualtyViewModel.Add(new CasualtyViewModel
                {
                    Id = casyalty.Id,
                    Name = casyalty.BirthDate.ToShortDateString() + " " + casyalty.Surname + " " + casyalty.Firstname + " " + casyalty.Lastname
                });
            }
            return casualtyViewModel;
        }
        private CasualtyModel ParseCreateViewModelToCasualtyModel(CasualtyCreatViewModel casualty)
        {
            CasualtyModel casyaltyModel = new CasualtyModel
            {
                Firstname = casualty.Firstname,
                Address = casualty.Address,
                BirthDate = casualty.BirthDate,
                Lastname = casualty.Lastname,
                Surname = casualty.Surname
            };
            return casyaltyModel;
        }

        #endregion
    }
}