using AM.EmergencyService.App.Data.AdServiceReference;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Data.Service
{
    public interface IAdService
    {
        IEnumerable<AdvertisingModel> GetAd(int numberOfAd);
    }
}
