using Cliente;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios
{
    internal static class ApplicationSettings
    {
        internal static String getLoggerImplementation() {
            return ConfigurationManager.AppSettings["loggerImplementation"];
        }

        internal static String getSqlLoggerConnectionString() {
            return ConfigurationManager.ConnectionStrings["azureLoggerDB"].ConnectionString;
        }

        internal static string getFileLoggerPath()
        {
            return ConfigurationManager.AppSettings["loggerPath"];
        }

        internal static string getLegacyLoggerSource()
        {
            return ConfigurationManager.AppSettings["legacyLoggerSource"];
        }

        internal static LoggerType getLegacyLoggerType()
        {
            try {
                String stringType = ConfigurationManager.AppSettings["legacyLoggerType"];
                LoggerType loggerType = (LoggerType)Enum.Parse(typeof(LoggerType), stringType);
                return loggerType;
            } catch (Exception ex) {
                return LoggerType.FILE;
            }

        }
    }
}
