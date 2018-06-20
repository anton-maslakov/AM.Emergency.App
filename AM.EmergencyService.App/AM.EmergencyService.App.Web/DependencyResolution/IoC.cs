namespace AM.EmergencyService.App.Web.DependencyResolution
{
    using AM.EmergencyService.App.DependencyResolution;
    using StructureMap;

    public static class IoC
    {
        public static IContainer Initialize()
        {
            return new Container(
                c =>
                {
                    c.AddRegistry<MainRegistry>();
                });
        }
    }
}