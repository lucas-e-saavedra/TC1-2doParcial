using System;
using System.Collections.Generic;
using Servicios.DAL.Contracts;
using Servicios.Domain;
using Servicios.DAL.Tools;
using Servicios.DAL.Factory;

namespace Servicios.DAL.Implementations
{
    internal class FileLogger : ILogger
    {
        private String filePath;
        internal FileLogger(String onePath) {
            filePath = onePath;
        }
        public List<Log> GetAll()
        {
            FileHelper fileHelper = new FileHelper(filePath);
            List<String> lines = fileHelper.Read();

            Converter<string, Log> converter = new Converter<string, Log>(LogMapper.fromString);
            return lines.ConvertAll<Log>(converter);
        }

        public void Store(Log oneLog)
        {
            FileHelper file = new FileHelper(filePath);
            file.Write(LogMapper.toString(oneLog));
        }
    }
}
