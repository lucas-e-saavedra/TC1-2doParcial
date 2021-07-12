using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.Factory
{
    internal class LogMapper
    {
        public static Log fromValues(object[] values) {
            EnumSeverity oneSeverity = (EnumSeverity)Enum.Parse(typeof(EnumSeverity), values[2].ToString());
            return new Log()
            {
                severity = oneSeverity,
                message = values[3].ToString(),
            };
        }

        public static Log fromString(String stringLog)
        {
            String stringSeverity = stringLog.Split(':').First();
            String stringMessage = stringLog.Substring(stringSeverity.Length +2);
            EnumSeverity logSeverity = (EnumSeverity)Enum.Parse(typeof(EnumSeverity), stringSeverity);
            return new Log()
            {
                severity = logSeverity,
                message = stringMessage
            };
        }

        public static String toString(Log oneLog) {
            return $"{oneLog.severity.ToString()}: {oneLog.message}";
        }
    }
}
