using System;
using System.Collections.Generic;

namespace Cliente
{
    public class Logger
    {
        private String source;
        private LoggerType type;
        
        //Esta propiedad la puse para tener los logs cargados en memoria a modo de ejemplo
        //Se supone que este logger ya viene implementado por el cliente y el definió como 
        //hará la persistencia en archivos o en la base de datos.
        private List<String> exampleLogs = new List<String>();

        public Logger(String path, LoggerType loggerType) {
            source = path;
            type = loggerType;
        }

        public void Write(String oneLog) {
            exampleLogs.Add(oneLog);
        }

        public String[]  ReadAll() {
            return exampleLogs.ToArray();
        }
    }

    public enum LoggerType
    { SQL, FILE }
}
