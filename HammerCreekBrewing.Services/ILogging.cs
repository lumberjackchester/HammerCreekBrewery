using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HammerCreekBrewing.Services
{
    public interface ILogging
    {
        void Init();
        void LogDebug(string message);
        void LogInfo(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogFatal(string message);
        void LogDebug(string message, Exception ex);
        void LogInfo(string message, Exception ex);
        void LogWarning(string message, Exception ex);
        void LogError(string message, Exception ex);
        void LogFatal(string message, Exception ex);
    }


}
