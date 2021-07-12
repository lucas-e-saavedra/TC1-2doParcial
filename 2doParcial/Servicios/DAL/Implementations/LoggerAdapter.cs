using Servicios.DAL.Contracts;
using Servicios.DAL.Factory;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.Implementations
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
                Log oneLog = LogMapper.fromString(oneLine);
                adaptedLogs.Add(oneLog);
            }
            return adaptedLogs;
        }

        public void Store(Log oneLog)
        {
            adaptee.Write(LogMapper.toString(oneLog));
        }
    }
}
