namespace AM.EmergencyService.App.Business.DependencyResolution
{
    using AM.EmergencyService.App.Business.Interface;
    using AM.EmergencyService.App.Business.Provider;
    using StructureMap;

    public class BusinessRegistry : Registry {
          public BusinessRegistry() {
            For<IAdProvider>().Use<AdProvider>();
            For<IDataProvider>().Use<DataProvider>();
        }
    }
}