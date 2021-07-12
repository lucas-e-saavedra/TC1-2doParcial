using Servicios.DAL.Contracts;
using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.DAL.Implementations.Decorator
{
    internal abstract class BaseLoggerDecorator: ILogger
    {
        protected ILogger wrapper;

        private BaseLoggerDecorator() { }
        internal BaseLoggerDecorator(ILogger parent) {
            wrapper = parent;
        }

        public abstract void Store(Log oneLog);
        public abstract List<Log> GetAll();
    }
}
