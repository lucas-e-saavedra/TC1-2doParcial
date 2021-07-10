using Servicios.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Servicios.Contracts
{
    public interface ILogger
    {
        void Store(Log oneLog);

        List<Log> GetAll();
    }
}
