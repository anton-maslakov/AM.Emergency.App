using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Web.Attributes;
using AM.EmergencyService.App.Web.Models.RequestDetail;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class RequestDetailController : Controller
    {
        private IRequestDetailsProvider _requestDetailsProvider;
        private IRequestDetailService _requestDetailService;

        public RequestDetailController(IRequestDetailsProvider requestDetailsProvider, IRequestDetailService requestDetailService)
        {
            ErrorHandlingHelper.IfArgumentNullException(requestDetailsProvider, "IRequestDetailsProvider");
            ErrorHandlingHelper.IfArgumentNullException(requestDetailService, "IRequestDetailService");
            _requestDetailsProvider = requestDetailsProvider;
            _requestDetailService = requestDetailService;
        }
        [Dispatcher]
        public ActionResult Details(int requestNumber)
        {
            var incidents = _requestDetailsProvider.GetRequestDetailsByRequestNumber(requestNumber);
            return View(incidents);
        }
        [Dispatcher]
        public ActionResult Edit(int requestNumber)
        {
            var requestDetail = ParseRequestDetailModelToCreatViewModel(_requestDetailsProvider.GetRequestDetailsByRequestNumber(requestNumber));
            if (requestDetail == null)
            {
                return RedirectToAction("Create", new { requestNumber = requestNumber });
            }
            else
            {
                return View(requestDetail);
            }
        }
        [HttpPost]
        public ActionResult Edit(RequestDetailCreateViewModel viewModel)
        {
            _requestDetailService.Edit(ParseCreateViewModelToRequestDetailModel(viewModel));
            if (viewModel.CasualtyId != null)
            {
                foreach (var casualty in viewModel.CasualtyId)
                {
                    _requestDetailService.AddCasualtyToRequestDetail(viewModel.RequestNumber, casualty);
                }
            }
            if (viewModel.InventoryNumber != null)
            {
                foreach (var inventory in viewModel.InventoryNumber)
                {
                    _requestDetailService.AddInventoryToRequestDetail(viewModel.RequestNumber, inventory);
                }
            }

            return RedirectToAction("Index", "Request");
        }
        [Dispatcher]
        public ActionResult Create(int requestNumber)
        {
            RequestDetailCreateViewModel viewModel = new RequestDetailCreateViewModel { RequestNumber = requestNumber };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(RequestDetailCreateViewModel viewModel)
        {
            _requestDetailService.Create(ParseCreateViewModelToRequestDetailModel(viewModel));
            if (viewModel.CasualtyId != null)
            {
                foreach (var casualty in viewModel.CasualtyId)
                {
                    _requestDetailService.AddCasualtyToRequestDetail(viewModel.RequestNumber, casualty);
                }
            }
            if (viewModel.InventoryNumber != null)
            {
                foreach (var inventory in viewModel.InventoryNumber)
                {
                    _requestDetailService.AddInventoryToRequestDetail(viewModel.RequestNumber, inventory);
                }
            }

            return RedirectToAction("Index", "Request");
        }

        #region PartialView
        [ChildActionOnly]
        public PartialViewResult ShowRequestDetails(int requestNumber)
        {
            ViewBag.brigadeNumber = requestNumber;
            var incident = _requestDetailsProvider.GetRequestDetailsByRequestNumber(requestNumber);
            if (incident != null)
            {
                return PartialView(ParseRequestDetailModelToViewModel(incident));
            }
            else
            {
                return null;
            }
        }
        #endregion

        #region Helper
        private RequestDetailModel ParseCreateViewModelToRequestDetailModel(RequestDetailCreateViewModel requestCreateViewModel)
        {
            RequestDetailModel requestModel = new RequestDetailModel
            {
                RequestNumber = requestCreateViewModel.RequestNumber,
                IncidentInformation = requestCreateViewModel.IncidentInformation,
                IncidentReason = requestCreateViewModel.IncidentReason,
                BrigadeArrivalDate = requestCreateViewModel.BrigadeArrivalDate,
                BrigadeCallDate = requestCreateViewModel.BrigadeCallDate,
                BrigadeEndDate = requestCreateViewModel.BrigadeEndDate,
                BrigadeNumber = requestCreateViewModel.BrigadeNumber,
                BrigadeReturnDate = requestCreateViewModel.BrigadeReturnDate
            };
            return requestModel;
        }
        private RequestDetailCreateViewModel ParseRequestDetailModelToCreatViewModel(RequestDetailModel requestDetailModel)
        {
            RequestDetailCreateViewModel requestModel = new RequestDetailCreateViewModel();
            if (requestDetailModel != null)
            {
                requestModel = new RequestDetailCreateViewModel
                {
                    RequestNumber = requestDetailModel.RequestNumber,
                    IncidentInformation = requestDetailModel.IncidentInformation,
                    IncidentReason = requestDetailModel.IncidentReason,
                    BrigadeArrivalDate = requestDetailModel.BrigadeArrivalDate,
                    BrigadeCallDate = requestDetailModel.BrigadeCallDate,
                    BrigadeEndDate = requestDetailModel.BrigadeEndDate,
                    BrigadeNumber = requestDetailModel.BrigadeNumber,
                    BrigadeReturnDate = requestDetailModel.BrigadeReturnDate
                };
            }
            else
            {
                return null;
            }
            return requestModel;
        }
        private RequestDetailViewModel ParseRequestDetailModelToViewModel(RequestDetailModel requestDetailModel)
        {
            RequestDetailViewModel requestModel = new RequestDetailViewModel
            {
                RequestNumber = requestDetailModel.RequestNumber,
                IncidentInformation = requestDetailModel.IncidentInformation,
                IncidentReason = requestDetailModel.IncidentReason,
                BrigadeArrivalDate = requestDetailModel.BrigadeArrivalDate,
                BrigadeCallDate = requestDetailModel.BrigadeCallDate,
                BrigadeEndDate = requestDetailModel.BrigadeEndDate,
                BrigadeNumber = requestDetailModel.BrigadeNumber,
                BrigadeReturnDate = requestDetailModel.BrigadeReturnDate
            };
            return requestModel;
        }
        #endregion
    }
}