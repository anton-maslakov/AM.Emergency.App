using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AM.EmergencyService.App.Web.Models;

namespace AM.EmergencyService.App.Web.Providers
{
    public class BrigadeProvider : IDataProvider
    {
        public IEnumerable<IModel> GetData()
        {
            var brigadeData = new List<BrigadeModel>()
            {
               new BrigadeModel() { Id = 1, BrigadeNumber=1},
               new BrigadeModel() { Id = 2, BrigadeNumber=2},
               new BrigadeModel() { Id = 3, BrigadeNumber=3},
               new BrigadeModel() { Id = 4, BrigadeNumber=4},
            };

            return brigadeData;
        }
    }
}