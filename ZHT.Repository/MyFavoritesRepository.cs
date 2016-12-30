using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using ZHT.Repository.Base;

namespace ZHT.Repository
{
  public  class MyFavoritesRepository: BaseRepository<MyFavorites>,IMyFavoritesRepository
    {
        public MyFavoritesRepository(IDataBaseFactory myfavoritesRepository) :base(myfavoritesRepository)
        {

        }
    }
}
