using Servicios.Contracts;
using Servicios.Implementations;
using System.Configuration;

namespace Servicios.Factory
{
    public sealed class ServicesFactory
    {
        private readonly static ServicesFactory _instance = new ServicesFactory();

        public static ServicesFactory Current
        {
            get
            {
                return _instance;
            }
        }

        private ServicesFactory()
        {
        }

        public ILogger GetLogger() {
            switch (ConfigurationManager.AppSettings["loggerImplementation"])
            {
                case "SqlLogger":
                    return new SqlLogger(ConfigurationManager.ConnectionStrings["azureLoggerDB"].ConnectionString);
                case "FileLogger":
                    return new FileLogger(ConfigurationManager.AppSettings["loggerPath"]);
                default:
                    return new FileLogger(ConfigurationManager.AppSettings["loggerPath"]);
            }
        }
    }
}
