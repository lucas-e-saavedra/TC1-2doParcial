using Servicios.BLL;
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
            LoggerFacade.Current.WriteLog("Este es un log de ejemplo");
            LoggerFacade.Current.WriteLog("La venganza nunca es buena, mata el alma y la envenena", Servicios.Domain.EnumSeverity.INFO);
            LoggerFacade.Current.WriteLog("Est es otro log", Servicios.Domain.EnumSeverity.INFO);
            LoggerFacade.Current.WriteLog("VAMOS A MORIR... CriticalError", Servicios.Domain.EnumSeverity.ERROR);
            LoggerFacade.Current.WriteLog("Se armó la gorda... FatalError", Servicios.Domain.EnumSeverity.ERROR);

            List<Servicios.Domain.Log> logs = LoggerFacade.Current.GetLogs();
            logs.ForEach(Console.WriteLine);
            Console.ReadKey();
        }
    }
}
