using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface ISeatSetService
    {
        void InsertSeatSet(SeatSet _seatSet);
        void Delete(SeatSet _seatSet);
        void Update(SeatSet _seatSet);
        SeatSet GetModelById(string id);
        List<SeatSet> GetAllList();
    }
}
