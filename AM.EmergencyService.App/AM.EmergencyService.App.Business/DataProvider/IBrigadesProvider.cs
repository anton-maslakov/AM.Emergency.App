using AM.EmergencyService.App.Common.Models;
using System;
using System.Collections.Generic;

namespace AM.EmergencyService.App.Business.DataProvider
{
    public interface IBrigadesProvider
    {
        IEnumerable<BrigadeModel> GetAllData();
        IEnumerable<BrigadeModel> GetBrigadeByDate(DateTime date);
    }
}
