using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestSynt.Conections
{
    public class Conection : IConection
    {
        private readonly IConfiguration configuration;

        private readonly ILogger logger;

        public Conection(ILogger<Conection> logger, IConfiguration configuration) {
            this.configuration = configuration;
        }

        public DataSet runStoreProcedure(string nameStoreProcedure, SqlParameter[] parameters)
        {
            try
            {
                
                DataSet dataSet = new DataSet();
                SqlConnection con = new SqlConnection(configuration.GetConnectionString("connectionString"));
                SqlDataAdapter adaptersQL = new SqlDataAdapter(nameStoreProcedure, con);
                adaptersQL.SelectCommand.CommandType = CommandType.StoredProcedure;
               
                if (parameters != null)
                {
                    for (int j = 0; j < parameters.Length; j++)
                    {
                        adaptersQL.SelectCommand.Parameters.Add(parameters[j]);
                    }
                }

                adaptersQL.Fill(dataSet);

                return dataSet;
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error en metodo runStoreProcedure");
                throw new Exception("Error en metodo runStoreProcedure", ex);
            }

        }
    }
}
