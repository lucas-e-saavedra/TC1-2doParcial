using Servicios.DAL.Contracts;
using Servicios.DAL.Implementations;
using System.Configuration;

namespace Servicios.DAL.Factory
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
                case "LegacyClientLogger":
                    Cliente.Logger legacyLogger = new Cliente.Logger("", Cliente.LoggerType.FILE);
                    return new LoggerAdapter(legacyLogger);
                default:
                    return new FileLogger(ConfigurationManager.AppSettings["loggerPath"]);
            }
        }
    }
}
