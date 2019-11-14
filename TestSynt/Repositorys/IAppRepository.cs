using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestSynt.Models;

namespace TestSynt.Repositorys
{
    public interface IAppRepository
    {
       

        void Create(AppModel data);

        void Update(AppModel data);

        void Delete(int id);

        AppModel GetById(int id);

        List<AppModel> GetAll();
      



    }
}
