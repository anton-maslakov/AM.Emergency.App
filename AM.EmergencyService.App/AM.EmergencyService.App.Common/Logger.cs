using log4net;
using log4net.Config;
using StructureMap;
using System;
using System.IO;

namespace AM.EmergencyService.App.Common
{
    class Logger : ILogger
    {
        
        private static ILog log = LogManager.GetLogger("LOGGER");
        public static ILog Log{ get { return log; } }
        public static void InitLogger()
        {
            XmlConfigurator.Configure();
        }
    }
}
