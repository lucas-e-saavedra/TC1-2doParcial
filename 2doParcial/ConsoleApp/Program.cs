using System;
using System.Collections.Generic;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //string bla = ConfigurationManager.ConnectionStrings["MainConString"].ConnectionString;
            //string alb = ConfigurationManager.AppSettings["PathLog"];

            Servicios.Domain.Log oneLog = new Servicios.Domain.Log();
            oneLog.message = "Hola";
            oneLog.severity = Servicios.Domain.EnumSeverity.DEBUG;
            Servicios.Factory.ServicesFactory.Current.GetLogger().Store(oneLog);
            List<Servicios.Domain.Log> logs = Servicios.Factory.ServicesFactory.Current.GetLogger().GetAll();            
            Console.ReadKey();
        }
    }
}
