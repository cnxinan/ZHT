using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface ITicketsTypeService
    {
        void InsertTicketsType(TicketsType _ticketsType);
        void Delete(TicketsType _ticketsType);
        void Update(TicketsType _ticketsType);
        TicketsType GetModelById(string id);

        List<TicketsType> GetAllList();
    }
}
