using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;

namespace AM.EmergencyService.App.Common.Logger
{
    public class Logger : ILogger
    {

        private static ILog log;

        public Logger()
        {
            InitiateLogger();
            log = LogManager.GetLogger("MyAwesomeLogger");
        }
        private void InitiateLogger()
        {
            var currentDirectory = Path.Combine(AppDomain.CurrentDomain.RelativeSearchPath, "log4net.config");
            var configFile= new FileInfo(currentDirectory);
            XmlConfigurator.ConfigureAndWatch(configFile);
        }
        void ILogger.Log(LogLevel level, string message)
        {
            switch (level)
            {
                case LogLevel.Debug:
                    log.Debug(message);
                    break;
                case LogLevel.Info:
                    log.Info(message);
                    break;
                case LogLevel.Warn:
                    log.Warn(message);
                    break;
                case LogLevel.Error:
                    log.Error(message);
                    break;
                case LogLevel.Fatal:
                    log.Fatal(message);
                    break;
            }
        }
    }
}
