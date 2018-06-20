using AM.EmergencyService.AdService.Interface;
using AM.EmergencyService.AdService.Model;
using AM.EmergencyService.AdService.Repository;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace AM.EmergencyService.AdService.Service
{
    [ServiceBehavior(AddressFilterMode = AddressFilterMode.Any)]
    public class AdService : IService
    {
        public IEnumerable<AdvertisingModel> GetAdvertising(int numberOfAd)
        {
            AdRepository repository = new AdRepository();
            return repository.GetAdvertising(numberOfAd);
        }
    }
}