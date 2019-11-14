using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace TestSynt.Conections
{
    public interface IConection
    {
        DataSet runStoreProcedure(string nameStoreProcedure, SqlParameter[] parameters);
    }
}
