using Servicios.DAL.Contracts;
using Servicios.DAL.Factory;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.BLL
{
    public sealed class LoggerFacade
    {
        private readonly static LoggerFacade _instance = new LoggerFacade();

        public static LoggerFacade Current
        {
            get
            {
                return _instance;
            }
        }

        private ILogger logger;
        private LoggerFacade()
        {
            logger = ServicesFactory.Current.GetLogger();
        }

        public void WriteLog(String logMessage, EnumSeverity logSeverity = EnumSeverity.DEBUG) {
            Log newLog = new Log();
            newLog.message = logMessage; 
            newLog.severity = logSeverity;
            logger.Store(newLog);
        }

        public List<Log> GetLogs() {
            return logger.GetAll() ;
        }

        public List<Log> GetLogs(EnumSeverity logSeverity) {
            return logger.GetAll().Where(item => item.severity == logSeverity).ToList();
        }
    }
}
