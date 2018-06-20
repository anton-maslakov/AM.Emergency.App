using AM.EmergencyService.App.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Web.Providers
{
    public interface IDataProvider
    {
        IEnumerable<IModel> GetData();
    }
}
