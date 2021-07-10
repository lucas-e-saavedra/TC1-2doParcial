using System;
using System.Collections.Generic;
using Servicios.Contracts;
using Servicios.Domain;
using Servicios.Tools;

namespace Servicios.Implementations
{
    internal class FileLogger : ILogger
    {
        private String filePath;
        internal FileLogger(String onePath) {
            filePath = onePath;
        }
        public List<Log> GetAll()
        {
            FileHelper fileHelper = new FileHelper(filePath);
            List<String> lines = fileHelper.Read();

            Converter<string, Log> converter = new Converter<string, Log>(convertLog);
            return lines.ConvertAll<Log>(converter);
        }
        private Log convertLog(String oneString) { 
            return new Log() { message = oneString, severity = EnumSeverity.DEBUG};
        }

        public void Store(Log oneLog)
        {
            FileHelper file = new FileHelper(filePath);
            file.Write($"Severity: {oneLog.severity}, message:{oneLog.message}");
        }
    }
}
