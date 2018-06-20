using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Data.AdServiceReference;
using AM.EmergencyService.App.Data.Service;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.AdProvider
{
    public class AdProvider : IAdProvider
    {
        private IAdService _adService;
        public AdProvider(IAdService adService)
        {
            ErrorHandlingHelper.IfArgumentNullException(adService, "IAdService");
            _adService = adService;
        }
        public IEnumerable<AdvertisingModel> GetAd(int numberOfAd)
        {
            return _adService.GetAd(numberOfAd);
        }
    }
}
