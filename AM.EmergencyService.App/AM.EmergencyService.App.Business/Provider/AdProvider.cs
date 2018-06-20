using AM.EmergencyService.App.Business.Interface;
using AM.EmergencyService.App.Data.AdServiceReference;
using AM.EmergencyService.App.Data.Service;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.Provider
{
    public class AdProvider : IAdProvider
    {
        private IAdService _provider;
        public AdProvider(IAdService provider)
        {
            _provider = provider;
        }
        public IEnumerable<AdvertisingModel> GetAd(int numberOfAd)
        {
            return _provider.GetAd(numberOfAd);
        }
    }
}
