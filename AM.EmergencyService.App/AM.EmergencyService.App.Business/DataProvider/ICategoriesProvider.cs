using AM.EmergencyService.App.Common.Models;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface ICategoriesProvider
    {
        IEnumerable<CategoryModel> GetCategories();
    }
}
