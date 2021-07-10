using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using Servicios.Contracts;
using Servicios.Domain;
using Servicios.Tools;

namespace Servicios.Implementations
{
    class SqlLogger : ILogger
    {
        private String connectionString;
        internal SqlLogger(String oneConnectionString)
        {
            connectionString = oneConnectionString;
        }

        public List<Log> GetAll()
        {
            List<Log> allItems = new List<Log>();
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            using (var dr = sqlHelper.ExecuteReader(SelectAllStatement, System.Data.CommandType.Text))
            {
                while (dr.Read())
                {
                    object[] values = new object[dr.FieldCount];
                    dr.GetValues(values);
                    EnumSeverity oneSeverity = (EnumSeverity)Enum.Parse(typeof(EnumSeverity), values[2].ToString());
                    Log oneLog = new Log()
                    {
                        severity = oneSeverity,
                        message = values[3].ToString(),
                    };
                    allItems.Add(oneLog);
                }
            }
            return allItems;
        }

        public void Store(Log oneLog)
        {
            String timeStamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            SqlHelper sqlHelper = new SqlHelper(connectionString);
            sqlHelper.ExecuteNonQuery(InsertStatement, System.Data.CommandType.Text, new SqlParameter[] {
                        new SqlParameter("@TimeStamp", timeStamp),
                        new SqlParameter("@Severity", oneLog.severity.ToString()),
                        new SqlParameter("@Message", oneLog.message)});
        }




        #region Statements
        private string InsertStatement
        {
            get => "INSERT INTO [dbo].[Log] (TimeStamp, Severity, Message) VALUES (@TimeStamp, @Severity, @Message)";
        }


        private string SelectOneStatement
        {
            get => "SELECT , TimeStamp, Severity, Message FROM [dbo].[Log] WHERE Id = @Id";
        }

        private string SelectAllStatement
        {
            get => "SELECT Id, TimeStamp, Severity, Message FROM [dbo].[Log]";
        }
        #endregion

    }
}
