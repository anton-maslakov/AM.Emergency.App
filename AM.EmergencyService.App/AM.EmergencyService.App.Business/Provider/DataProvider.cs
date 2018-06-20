using AM.EmergencyService.App.Business.Interface;
using AM.EmergencyService.App.Common.Models;
using AM.EmergencyService.App.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Business.Provider
{
    public class DataProvider : IDataProvider
    {
        private IRepository _repository;

        public DataProvider(IRepository repository)
        {
            _repository = repository;
        }
        public IDataManipulator<BrigadeModel> Brigades { get { return _repository.Brigades; } }

        public IDataManipulator<RescuerModel> Rescuers { get { return _repository.Rescuers; } }

        public IDataManipulator<RequestModel> Requests { get { return _repository.Requests; } }
        public IDataManipulator<InventoryModel> Inventory { get { return _repository.Inventory; } }
        public IDataManipulator<IncidentModel> Incidents { get { return _repository.Incidents; } }
    }
}
