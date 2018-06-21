using AM.EmergencyService.App.Business.DataProvider;
using AM.EmergencyService.App.Business.Service;
using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Web.Attributes;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class InventoryController : Controller
    {
        private IInventoryProvider _inventoryProvider;
        private IInventoryService _inventoryService;
        public InventoryController(IInventoryProvider inventoryProvider, IInventoryService inventoryService)
        {
            ErrorHandlingHelper.IfArgumentNullException(inventoryProvider, "IInventoryProvider");
            ErrorHandlingHelper.IfArgumentNullException(inventoryService, "IInventoryService");
            _inventoryService = inventoryService;
            _inventoryProvider = inventoryProvider;
        }
        public ActionResult Index()
        {
            var inventoryList = _inventoryProvider.GetAllData();
            return View(inventoryList);
        }
        [Editor]
        public ActionResult Create()
        {
            var inventory = new InventoryModel();
            return View(inventory);
        }
        [Editor]
        [HttpPost]
        public ActionResult Create(InventoryModel inventory)
        {
            _inventoryService.Create(inventory);
            return RedirectToAction("Index");
        }
        [Editor]
        public ActionResult Edit(int inventoryNumber)
        {
            var inventory = _inventoryProvider.GetInventoryByNumber(inventoryNumber);
            return View(inventory);
        }
        [HttpPost]
        public ActionResult Edit(InventoryModel inventoryModel)
        {
            _inventoryService.Edit(inventoryModel);
            return RedirectToAction("Index");
        }
        [Editor]
        public ActionResult DeleteInventoryFromBrigade(int brigadeNumber, int inventoryNumber)
        {
            _inventoryService.DeleteInventoryFromBrigade(brigadeNumber, inventoryNumber);
            return RedirectToAction("Details","Brigade", new { brigadeNumber = brigadeNumber });
        }
        [Dispatcher]
        public ActionResult DeleteInventoryFromRequest(int requestNumber, int inventoryNumber)
        {
            _inventoryService.DeleteInventoryFromRequest(requestNumber, inventoryNumber);
            return RedirectToAction("Details", "RequestDetail", new { requestNumber = requestNumber });
        }
      
        #region PartialViews
        [ChildActionOnly]
        public PartialViewResult SelectInventory(int requestNumber)
        {
            IEnumerable<InventoryModel> inventoryList = null;
            if (requestNumber < 0)
            {
                inventoryList = _inventoryProvider.GetAllData();
            }
            else
            {
                inventoryList = _inventoryProvider.GetInventoryNotInRequest(requestNumber);

            }
            if (inventoryList != null)
            {
                return PartialView(inventoryList);
            }
            else
            {
                return null;
            }
        }
        [ChildActionOnly]
        public PartialViewResult ShowBrigadeInventory(int brigadeNumber)
        {
            ViewBag.brigadeNumber = brigadeNumber;
            var inventoryList = _inventoryProvider.GetInventoryByBrigadeNumber(brigadeNumber);
            if (inventoryList != null)
            {
                return PartialView(inventoryList);
            }
            else
            {
                return null;
            }
        }
        [ChildActionOnly]
        public PartialViewResult ShowRequestInventory(int requestNumber)
        {
            ViewBag.requestNumber = requestNumber;
            var inventoryList = _inventoryProvider.GetInventoryByRequestNumber(requestNumber);
            if (inventoryList != null)
            {
                return PartialView(inventoryList);
            }
            else
            {
                return null;
            }
        }
        #endregion
    }
}