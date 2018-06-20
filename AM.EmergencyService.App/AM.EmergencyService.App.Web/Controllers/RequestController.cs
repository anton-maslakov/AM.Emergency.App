using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Web.Attributes;
using AM.EmergencyService.App.Web.Models.Request;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class RequestController : Controller
    {
        private static ILogger _logger;
        private IRequestsProvider _requestsProvider;
        private ICategoriesProvider _categoriesProvider;
        private IRequestDetailsProvider _requestDetailsProvider;
        private IRequestService _requestService;

        public RequestController(IRequestService requestService, IRequestsProvider requestsProvider, ICategoriesProvider categoriesProvider, IRequestDetailsProvider requestDetailsProvider, ILogger logger)
        {
            ErrorHandlingHelper.IfArgumentNullException(categoriesProvider, "ICategoriesProvider");
            ErrorHandlingHelper.IfArgumentNullException(requestsProvider, "IRequestsProvider");
            ErrorHandlingHelper.IfArgumentNullException(requestDetailsProvider, "IRequestDetailsProvider");
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            _requestsProvider = requestsProvider;
            _categoriesProvider = categoriesProvider;
            _requestDetailsProvider = requestDetailsProvider;
            _requestService = requestService;
            _logger = logger;
        }

        public ActionResult Index()
        {
            _logger.Log(LogLevel.Info, "RequestPage is running.");
            return View();
        }
        public ActionResult Search()
        {
            return View();
        }
        [Dispatcher]
        public ActionResult RequestList()
        {
            var requestList = ParseRequestListToViewModelList(_requestsProvider.GetAllData());
            return PartialView(requestList);
        }

        [Dispatcher]
        public ActionResult GetDataSearch(string SearchBy, string SearchValue, string SearchDate)
        {
            IEnumerable<RequestViewModel> requestList = new List<RequestViewModel>();

            if (!string.IsNullOrEmpty(SearchValue))
            {
                switch (SearchBy)
                {
                    case "requestNumber":
                        {
                            requestList = ParseRequestListToViewModelList(_requestsProvider.GetRequestByNumber(Int32.Parse(SearchValue), SearchDate));
                            break;
                        }
                    case "requestCategory":
                        {
                            requestList = ParseRequestListToViewModelList(_requestsProvider.GetRequestByCategory(SearchValue, SearchDate));
                            break;
                        }
                    case "requestAddress":
                        {
                            requestList = ParseRequestListToViewModelList(_requestsProvider.GetRequestByAddress(SearchValue, SearchDate));
                            break;
                        }
                }
            }
            else
            {
                return View();
            }
            return PartialView("RequestList", requestList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(RequestCreateViewModel requestViewModel)
        {
            _requestService.Create(ParseCreateViewModelToRequestModel(requestViewModel));
            return RedirectToAction("Index");
        }
        [ChildActionOnly]
        public PartialViewResult SelectCategory()
        {
            var categoryList = _categoriesProvider.GetCategories();
            if (categoryList != null)
            {
                return PartialView(categoryList);
            }
            else
            {
                return null;
            }
        }

        #region Helpers
        private List<RequestViewModel> ParseRequestListToViewModelList(IEnumerable<RequestModel> requestList)
        {
            List<RequestViewModel> requestViewModelList = new List<RequestViewModel>();
            foreach (RequestModel request in requestList)
            {
                requestViewModelList.Add(new RequestViewModel
                {
                    RequestNumber = request.RequestNumber,
                    RequestAddress = request.RequestAddress,
                    RequestDate = request.RequestDate,
                    RequestReason = request.RequestReason,
                    CategoryName = request.Category.CategoryName
                });
            }
            return requestViewModelList;
        }
        private RequestModel ParseCreateViewModelToRequestModel(RequestCreateViewModel requestCreateViewModel)
        {
            RequestModel requestModel = new RequestModel
            {
                RequestAddress = requestCreateViewModel.RequestAddress,
                RequestReason = requestCreateViewModel.RequestReason,
                Category = new CategoryModel { Id = requestCreateViewModel.CategoryId }
            };
            return requestModel;
        }
        #endregion
    }
}



