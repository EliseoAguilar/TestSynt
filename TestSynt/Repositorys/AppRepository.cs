using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using TestSynt.Conections;
using TestSynt.Models;

namespace TestSynt.Repositorys
{
    public class AppRepository : IAppRepository
    {
        private readonly IConection conection;


        public AppRepository(IConection conection)
        {
            this.conection = conection;
        }


        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<AppModel> GetAll()
        {

            List<AppModel> list = new List<AppModel>();

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@OPT", SqlDbType.Int){
                      Value = 1,
                      Direction = ParameterDirection.Input
                      }
                };

            DataSet dataSet = conection.runStoreProcedure("USP_CRUD_APP", parameters);

            if (dataSet.Tables.Count != 0)
            {

                DataTable dtApps = dataSet.Tables[0];

                foreach (DataRow dataAppTemp in dtApps.Rows)
                {
                    list.Add(new AppModel
                    {
                        Id = dataAppTemp["ID"].ToString(),
                        Name = dataAppTemp["NAME"].ToString(),
                        URL = dataAppTemp["URL"].ToString(),
                    });
                }
            }

            return list;
        }

        public AppModel GetById(int id)
        {
            AppModel data = null;

            SqlParameter[] parameters = new SqlParameter[] {
                new SqlParameter("@OPT", SqlDbType.Int){
                      Value = 4,
                      Direction = ParameterDirection.Input
                      },
                 new SqlParameter("@ID", SqlDbType.Int){
                      Value = id,
                      Direction = ParameterDirection.Input
                  }
                };

            DataSet dataSet = conection.runStoreProcedure("USP_CRUD_APP", parameters);

            if (dataSet.Tables.Count != 0)
            {

                DataTable dtApps = dataSet.Tables[0];

                foreach (DataRow dataAppTemp in dtApps.Rows)
                {
                    data = new AppModel
                    {
                        Id = dataAppTemp["ID"].ToString(),
                        Name = dataAppTemp["NAME"].ToString(),
                        URL = dataAppTemp["URL"].ToString(),
                    };
                }
            }

            return data;
        }

        public void Update(AppModel data)
        {
            throw new NotImplementedException();
        }

        public void Create(AppModel data)
        {
            throw new NotImplementedException();
        }
    }
}
