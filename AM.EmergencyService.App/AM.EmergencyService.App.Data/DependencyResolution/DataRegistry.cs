namespace AM.EmergencyService.App.Data.DependencyResolution
{
    using AM.EmergencyService.App.Data.Repository;
    using AM.EmergencyService.App.Data.Service;
    using StructureMap;

    public class DataRegistry : Registry {
        public DataRegistry()
        {
            For<IRepository>().Use<Repository>();
            For<IAdService>().Use<AdService>().Singleton();
        }
    }
}