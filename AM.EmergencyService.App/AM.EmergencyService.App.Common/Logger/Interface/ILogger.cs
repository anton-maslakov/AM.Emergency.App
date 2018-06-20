using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.EmergencyService.App.Common.Logger
{
    public interface ILogger
    {
        void Log(LogLevel level, string message);
    }

    public enum LogLevel { Debug, Info, Warn, Error, Fatal }
}
