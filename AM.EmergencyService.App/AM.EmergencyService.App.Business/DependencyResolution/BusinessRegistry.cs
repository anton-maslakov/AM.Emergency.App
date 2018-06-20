namespace AM.EmergencyService.App.Business.DependencyResolution
{
    using AM.EmergencyService.App.Business.AdProvider;
    using AM.EmergencyService.App.Business.DataProvider;
    using AM.EmergencyService.App.Business.DataProvider.Impl;
    using AM.EmergencyService.App.Common.Logger;
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
        }
    }
}