using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IUserInfoService
    {
        void InsertUserInfo(UserInfo _userInfo);
        void Delete(UserInfo _userInfo);
        void Update(UserInfo _userInfo);
        UserInfo GetModelById(string id);

        List<UserInfo> GetAllList();
    }
}
