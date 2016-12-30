using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IMyFavoritesService
    {
        void Insert(MyFavorites myFavorites);
        void Delete(MyFavorites myFavorites);
        void Update(MyFavorites myFavorites);
        MyFavorites GetModelById(string id);
        List<MyFavorites> GetAllList();
        MyFavorites GetModelByTargetIdAndUserId(string targetId, string userId);
    }
}
