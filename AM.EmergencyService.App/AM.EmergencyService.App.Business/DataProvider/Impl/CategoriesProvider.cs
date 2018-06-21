using AM.EmergencyService.App.Common.Helper;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider.Impl
{
    public class CategoriesProvider : ICategoriesProvider
    {
        ILogger _logger;
        ICategoriesRepository _repos;
        public CategoriesProvider(ILogger logger, ICategoriesRepository repos)
        {
            ErrorHandlingHelper.IfArgumentNullException(logger, "ILogger");
            ErrorHandlingHelper.IfArgumentNullException(repos, "ICategoriesRepository");
            _logger = logger;
            _repos = repos;
        }

        public IEnumerable<CategoryModel> GetCategories()
        {
            return _repos.GetCategories();
        }
    }
}
