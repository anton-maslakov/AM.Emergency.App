using AM.EmergencyService.App.Business.Interface;
using AM.EmergencyService.App.Data.AdServiceReference;
using System.Collections.Generic;
using System.Web.Mvc;

namespace AM.EmergencyService.App.Web.Controllers
{
    public class AdvertisingController : Controller
    {
        private const int NUM_OF_AD = 3;

        private IAdProvider _adProvider; 
        public AdvertisingController(IAdProvider adProvider)
        {
            _adProvider = adProvider;
        }
        public ActionResult GetAdvertising()
        {
            IEnumerable<AdvertisingModel> listOfAd = _adProvider.GetAd(NUM_OF_AD);
            return PartialView("GetAd",listOfAd);
        }
    }
}