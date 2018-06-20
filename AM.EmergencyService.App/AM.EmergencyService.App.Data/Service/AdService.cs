using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using System.Text;
using System.Threading.Tasks;
using AM.EmergencyService.App.Data.AdServiceReference;

namespace AM.EmergencyService.App.Data.Service
{
    public class AdService : IAdService
    {
        private IService _client;

        public AdService()
        {
            ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
            fileMap.ExeConfigFilename = Path.Combine(AppDomain.CurrentDomain.SetupInformation.PrivateBinPath, "App.config");
            Configuration newConfiguration = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
            ConfigurationChannelFactory<IService> factory = new ConfigurationChannelFactory<IService>("BasicHttpBinding_IService", newConfiguration, null);

            //var myBinding = new BasicHttpBinding();
            //var myEndpoint = new EndpointAddress("http://localhost:56945/Service.svc");
            //var myChannelFactory = new ChannelFactory<IAdService>(myBinding, myEndpoint);

            _client = factory.CreateChannel();
        }
        public IEnumerable<AdvertisingModel> GetAd(int numberOfAd)
        {
            IEnumerable<AdvertisingModel> listOfAd;
            listOfAd = _client.GetAdvertising(numberOfAd);
            return listOfAd;
        }

    }
}
