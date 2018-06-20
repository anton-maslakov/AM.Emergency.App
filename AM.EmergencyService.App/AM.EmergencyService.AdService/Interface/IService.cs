using AM.EmergencyService.AdService.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace AM.EmergencyService.AdService.Interface
{
    [ServiceContract(Namespace = "http://AM.EmergencyService.AdService.Interface")]
    public interface IService
    {

        [OperationContract]
        IEnumerable<AdvertisingModel> GetAdvertising(int numberOfAd);

        // TODO: Добавьте здесь операции служб
    }
}
