using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceModel.Configuration;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Common.Models;

namespace AM.EmergencyService.App.Data.Repository
{
    public class ConnectionStringInitialiser
    {
        private const string _CONNECTION_STRING = "EmergencyServiceConnection";
        private static string _conn;
        private static ILogger _logger;

        public ConnectionStringInitialiser(ILogger logger)
        {
            _logger = logger;
        }

        public static string InitConnectionString()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "App.config");
            Configuration newConfiguration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            _conn = newConfiguration.ConnectionStrings.ConnectionStrings[_CONNECTION_STRING].ConnectionString;
            return _conn;
        }
    }
}
