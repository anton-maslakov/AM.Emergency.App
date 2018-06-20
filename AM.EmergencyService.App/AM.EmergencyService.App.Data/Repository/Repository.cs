using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceModel.Configuration;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Data.Repository
{
    public class Repository : IRepository
    {
        private const string _CONNECTION_STRING = "EmergencyServiceConnection";
        private string _conn;
        private static ILogger _logger;

        public Repository(ILogger logger)
        {
            _logger = logger;
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "App.config");
            Configuration newConfiguration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            _conn = newConfiguration.ConnectionStrings.ConnectionStrings[_CONNECTION_STRING].ConnectionString;
        }

        public IDataManipulator<BrigadeModel> Brigades { get { return new BrigadesManipulator(_conn, _logger); } }

        public IDataManipulator<RequestModel> Requests { get { return new RequestManipulator(_conn, _logger); } }

        public IDataManipulator<RescuerModel> Rescuers { get { return new RescuersManipulator(_conn, _logger); } }
        public IDataManipulator<InventoryModel> Inventory { get { return new InventoryManipulator(_conn, _logger); } }
        public IDataManipulator<IncidentModel> Incidents { get { return new IncidentManipulator(_conn, _logger); } }
    }
}
