using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IRequestDetailsProvider
    {
       RequestDetailModel GetRequestDetailsByRequestNumber(int requestNumber);
    }
}
