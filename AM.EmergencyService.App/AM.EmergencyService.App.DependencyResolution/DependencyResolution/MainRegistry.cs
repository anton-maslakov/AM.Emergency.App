using AM.EmergencyService.App.Business.DependencyResolution;
using AM.EmergencyService.App.Common.DependencyResolution;
using AM.EmergencyService.App.Common.Logger;
using AM.EmergencyService.App.Data.DependencyResolution;
using StructureMap;

namespace AM.EmergencyService.App.DependencyResolution
{
    public class MainRegistry : Registry
    {
        public MainRegistry()
        {

            Scan(scan =>
            {
                scan.AssemblyContainingType<DataRegistry>();
                scan.AssemblyContainingType<BusinessRegistry>();
                scan.AssemblyContainingType<CommonRegistry>();
                //scan.WithDefaultConventions();
                scan.LookForRegistries();
            });
        }

    }
}
