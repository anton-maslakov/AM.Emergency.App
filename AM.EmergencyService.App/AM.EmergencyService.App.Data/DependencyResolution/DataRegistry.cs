namespace AM.EmergencyService.App.Data.DependencyResolution
{
    using AM.EmergencyService.App.Data.Repository;
    using AM.EmergencyService.App.Data.Repository.Impl;
    using AM.EmergencyService.App.Data.Service;
    using StructureMap;

    public class DataRegistry : Registry {
        public DataRegistry()
        {
            For<IBrigadesRepository>().Use<BrigadesRepository>();
            For<ICasualtyRepository>().Use<CasualtyRepository>();
            For<IInventoryRepository>().Use<InventoryRepository>();
            For<IRequestDetailsRepository>().Use<RequestDetailRepository>();
            For<IRequestsRepository>().Use<RequestsRepository>();
            For<IRescuersRepository>().Use<RescuersRepository>();
            For<IAdService>().Use<AdService>().Singleton();
            For<IUserRepository>().Use<UserRepository>();
        }
    }
}