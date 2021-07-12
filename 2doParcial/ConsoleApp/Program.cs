using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Implementacion 1
            Servicios.Domain.Log oneLog = new Servicios.Domain.Log();
            oneLog.message = "Hola";
            oneLog.severity = Servicios.Domain.EnumSeverity.DEBUG;
            Servicios.Factory.ServicesFactory.Current.GetLogger().Store(oneLog);
            List<Servicios.Domain.Log> logs = Servicios.Factory.ServicesFactory.Current.GetLogger().GetAll();*/

            //Implementacion 2
            Servicios.BLL.LoggerFacade.Current.WriteLog("Este es un log de ejemplo", Servicios.Domain.EnumSeverity.ERROR);
            Servicios.BLL.LoggerFacade.Current.WriteLog("Est es otro log");
            List<Servicios.Domain.Log> logs = Servicios.BLL.LoggerFacade.Current.GetLogs();
            Console.ReadKey();
        }
    }
}
