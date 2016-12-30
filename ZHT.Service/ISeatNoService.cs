using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface ISeatNoService
    {
        void Insert(SeatNo seatNo);
        void Delete(SeatNo seatNo);
        void Update(SeatNo seatNo);
        SeatNo GetModelById(string id);
        List<SeatNo> GetAllList();
    }
}
