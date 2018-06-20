
using AM.EmergencyService.App.Data.AdServiceReference;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.Interface
{
    public interface IAdProvider
    {
        IEnumerable<AdvertisingModel> GetAd(int numberOfAd);
    }
}
