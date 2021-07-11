using Servicios.Contracts;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Implementations
{
    class LoggerAdapter : ILogger
    {
        private Cliente.Logger adaptee;

        public LoggerAdapter(Cliente.Logger objectToAdapt) {
            adaptee = objectToAdapt;
        }

        public List<Log> GetAll()
        {
            String[] legacyLogs = adaptee.ReadAll();
            List<Log> adaptedLogs = new List<Log>();
            foreach (string oneLine in legacyLogs) {
                Log oneLog = new Log() { message = oneLine, severity = EnumSeverity.DEBUG };
                adaptedLogs.Add(oneLog);
            }
            return adaptedLogs;
        }

        public void Store(Log oneLog)
        {
            adaptee.Write(oneLog.message);
        }
    }
}
