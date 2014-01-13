using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Config;

namespace HammerCreekBrewing.Services
{
    public class Logging : ILogging  
    {
        private static readonly ILog log = LogManager.GetLogger(typeof(Logging));

        public  void Init()
        {

            log4net.Config.XmlConfigurator.Configure();


        }

        public void LogDebug(string message)
        {
            log.Debug(message);
        }

        public void LogInfo(string message)
        {
            log.Info(message);
        }

        public void LogWarning(string message)
        {
            log.Warn(message);
        }

        public void LogError(string message)
        {
            log.Error(message);
        }

        public void LogFatal(string message)
        {
            log.Error(message);
        }

        //*********************************************************************************//

        public void LogDebug(string message, Exception ex)
        {
            log.Debug(message, ex);
        }

        public void LogInfo(string message, Exception ex)
        {
            log.Info(message, ex);
        }

        public void LogWarning(string message, Exception ex)
        {
            log.Warn(message, ex);
        }

        public void LogError(string message, Exception ex)
        {
            log.Error(message, ex);
        }

        public void LogFatal(string message, Exception ex)
        {
            log.Error(message, ex);
        }




    }
}
