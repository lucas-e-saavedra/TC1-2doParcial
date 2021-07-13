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

        internal static string getEmailHost()
        {
            return ConfigurationManager.AppSettings["LogEmail_Host"];
        }
        internal static int getEmailPort()
        {
            try {
                string port = ConfigurationManager.AppSettings["LogEmail_Port"];
                return int.Parse(port);
            } catch {
                return 0;
            }
        }
        internal static string getEmailSenderAccount()
        {
            return ConfigurationManager.AppSettings["LogEmail_FromEmail"];
        }
        internal static string getEmailSenderPassword()
        {
            return ConfigurationManager.AppSettings["LogEmail_Password"];
        }
        internal static string getEmailCriticalErrorAddress()
        {
            return ConfigurationManager.AppSettings["EmailCriticalError"];
        }
        internal static string getEmailFatalErrorAddress()
        {
            return ConfigurationManager.AppSettings["EmailFatalError"];
        }
    }
}
