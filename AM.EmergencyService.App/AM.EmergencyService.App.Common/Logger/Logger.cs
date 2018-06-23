using log4net;
using log4net.Config;
using System;
using System.IO;
using System.Reflection;
using static System.Net.Mime.MediaTypeNames;

namespace AM.EmergencyService.App.Common.Logger
{
    public class Logger : ILogger
    {

        private static ILog log;

        public Logger()
        {
            log = LogManager.GetLogger("LogFileAppender");
            InitiateLogger();
        }
        private void InitiateLogger()
        {
            var configPath = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "log4net.config", SearchOption.AllDirectories);
            var configFile = new FileInfo(configPath[0]);
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
