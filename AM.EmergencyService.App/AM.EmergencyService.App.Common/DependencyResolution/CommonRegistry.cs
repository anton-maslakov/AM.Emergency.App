namespace AM.EmergencyService.App.Common.DependencyResolution {
    using AM.EmergencyService.App.Common.Logger;
    using StructureMap;

    public class CommonRegistry : Registry {
     
        public CommonRegistry() {
            For<ILogger>().Use<Logger>().Singleton();
        }
    }
}