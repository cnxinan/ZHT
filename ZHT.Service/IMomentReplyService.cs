using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IMomentReplyService
    {
        void Insert(MomentReply momentReply);
        void Delete(MomentReply momentReply);
        void Update(MomentReply momentReply);
        MomentReply GetModelById(string id);
        List<MomentReply> GetAllList();
    }
}
