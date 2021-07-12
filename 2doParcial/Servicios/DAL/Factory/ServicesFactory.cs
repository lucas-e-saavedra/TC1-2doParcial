using Servicios.DAL.Contracts;
using Servicios.DAL.Implementations;
using Servicios.DAL.Implementations.Decorator;

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
            switch (ApplicationSettings.getLoggerImplementation())
            {
                case "SqlLogger":
                    return new SqlLogger(ApplicationSettings.getSqlLoggerConnectionString());
                case "LegacyClientLogger":
                    Cliente.Logger legacyLogger = new Cliente.Logger(ApplicationSettings.getLegacyLoggerSource(), ApplicationSettings.getLegacyLoggerType());
                    //return new LoggerAdapter(legacyLogger);
                    return new EmailDecorator(new LoggerAdapter(legacyLogger));
                default:
                    return new FileLogger(ApplicationSettings.getFileLoggerPath());
            }
        }
    }
}
