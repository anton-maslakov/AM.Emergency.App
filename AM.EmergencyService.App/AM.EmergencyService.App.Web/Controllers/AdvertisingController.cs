using AM.EmergencyService.App.Business.AdProvider;
using AM.EmergencyService.App.Common.Helper;
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
            ErrorHandlingHelper.IfArgumentNullException(adProvider, "IAdProvider");
            _adProvider = adProvider;
        }
        public PartialViewResult ShowAdvertising()
        {
            var listOfAd = _adProvider.GetAd(NUM_OF_AD);
            if (listOfAd==null)
            {
                return PartialView("NoAdvertising");
            }
            else
            {
                return PartialView(listOfAd);
            }
        }
    }
}