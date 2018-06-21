using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;

namespace AM.EmergencyService.App.Business.Service.Impl
{
    public class RescuerService:IRescuersService
    {
        private ILogger _logger;
        private IRescuersRepository _repos;
        public RescuerService(ILogger logger, IRescuersRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "IRescuersRepository");
            _logger = logger;
            _repos = repos;
        }

        public void Add(RescuerModel rescuerModel)
        {
            _repos.Create(rescuerModel);
        }

        public void DeleteRescuerFromBrigade(int brigadeNumber, int rescuerId)
        {
            _repos.DeleteRescuerFromBrigade(brigadeNumber, rescuerId);
        }

        public void Edit(RescuerModel rescuerModel)
        {
            _repos.Edit(rescuerModel);
        }
    }
}
