namespace AM.EmergencyService.App.Web.DependencyResolution
{
    using StructureMap;

    public class DefaultRegistry : Registry {
        public DefaultRegistry() {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
					scan.With(new ControllerConvention());
                });
        }
    }
}