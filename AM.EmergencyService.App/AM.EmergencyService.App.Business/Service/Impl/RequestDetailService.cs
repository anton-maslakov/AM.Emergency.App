using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class RequestDetailService:IRequestDetailService
    {
        ILogger _logger;
        IRequestDetailsRepository _repos;

        public RequestDetailService(ILogger logger, IRequestDetailsRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IRequestDetailsRepository");
            _logger = logger;
            _repos = repos;
        }

        public void AddCasualtyToRequestDetail(int requestNumber, int casualtyId)
        {
            _repos.AddCasualtyToRequestDetail(requestNumber, casualtyId);
        }

        public void AddInventoryToRequestDetail(int requestNumber, int inventoryNumber)
        {
            _repos.AddInventoryToRequestDetail(requestNumber, inventoryNumber);
        }

        public void Create(RequestDetailModel requestDetailModel)
        {
            _repos.Create(requestDetailModel);
        }

    }
}
