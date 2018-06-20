using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Data.AdServiceReference;

namespace AM.EmergencyService.App.Data.Service
{
    public class AdService : IAdService
    {
        private IService _client;
        private ILogger _logger;

        public AdService(ILogger logger)
        {
            _logger = logger;
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "App.config");
            Configuration newConfiguration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            ConfigurationChannelFactory<IService> factory = new ConfigurationChannelFactory<IService>("BasicHttpBinding_IService", newConfiguration, null);
            _client = factory.CreateChannel();

        }
        public IEnumerable<AdvertisingModel> GetAd(int numberOfAd)
        {
            IEnumerable<AdvertisingModel> listOfAd;
            try
            {
                listOfAd = _client.GetAdvertising(numberOfAd);
            }
            catch (EndpointNotFoundException ex)
            {
                _logger.Log(LogLevel.Error, ex.Message);
                listOfAd = null;
            }
            return listOfAd;
        }
    }
}
