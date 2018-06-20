using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Data.Repository
{
    public interface IDataManipulator<T>
    {
        IEnumerable<T> GetData(string sqlInjection);
    }
}
