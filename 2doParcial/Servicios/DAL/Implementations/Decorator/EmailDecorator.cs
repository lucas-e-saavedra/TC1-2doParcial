using Servicios.DAL.Contracts;
using Servicios.DAL.Factory;
using Servicios.Domain;
using System.Collections.Generic;

namespace Servicios.DAL.Implementations.Decorator
{
    internal class EmailDecorator : BaseLoggerDecorator
    {
        public EmailDecorator(ILogger parent) : base(parent){ }

        public override List<Log> GetAll()
        {
            return wrapper.GetAll();
        }

        public override void Store(Log oneLog)
        {
            wrapper.Store(oneLog);
            if (oneLog.message.Contains("CriticalError")) {
                sendEmail("soporteNivel1@email.com", "CriticalError", LogMapper.toString(oneLog));
            }
            if (oneLog.message.Contains("FatalError")) {
                sendEmail("soporteNivel2@email", "FatalError", LogMapper.toString(oneLog));
            }
        }

        private void sendEmail(string to, string title, string message) { 
        }
    }
}
