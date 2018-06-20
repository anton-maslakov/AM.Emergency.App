namespace AM.EmergencyService.App.Business.DependencyResolution
{
    using AM.EmergencyService.App.Business.AdProvider;
    using AM.EmergencyService.App.Business.DataProvider;
    using AM.EmergencyService.App.Business.DataProvider.Impl;
    using AM.EmergencyService.App.Business.Service;
    using AM.EmergencyService.App.Business.Service.Impl;
    using StructureMap;

    public class BusinessRegistry : Registry {
          public BusinessRegistry() {
            For<IAdProvider>().Use<AdProvider>();
            For<IBrigadesProvider>().Use<BrigadesProvider>();
            For<ICasualtyProvider>().Use<CasualtyProvider>();
            For<IInventoryProvider>().Use<InventoryProvider>();
            For<IRequestDetailsProvider>().Use<RequestDetailsProvider>();
            For<IRequestsProvider>().Use<RequestsProvider>();
            For<IRescuersProvider>().Use<RescuersProvider>();
            For<ICategoriesProvider>().Use<CategoriesProvider>();
            For<IUserLogin>().Use<UserLogin>();
            For<ICacheService>().Use<ÑacheService>();
            For<IBrigadeService>().Use<BrigadeService>();
            For<ICasualtyService>().Use<CasualtyService>();
            For<IInventoryService>().Use<InventoryService>();
            For<IRequestDetailService>().Use<RequestDetailService>();
            For<IRequestService>().Use<RequestService>();
            For<IRescuersService>().Use<RescuerService>();
            For<IUserProvider>().Use<UserProvider>();
            For<IRoleProvider>().Use<RoleProvider>();
            For<IUserService>().Use<UserService>();
        }
    }
}