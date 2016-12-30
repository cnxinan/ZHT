using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IFollowMomentService
    {
        void Insert(FollowMoment followMoment);
        void Delete(FollowMoment followMoment);
        void Update(FollowMoment followMoment);
        FollowMoment GetModelById(string id);
        List<FollowMoment> GetAllList();
        FollowMoment GetModelByMomentIdAndUserId(string momentId, string userId);
    }
}
