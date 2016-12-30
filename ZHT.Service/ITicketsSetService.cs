using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public  interface ITicketsSetService
    {
        void InsertTicketsSet(TicketsSet _ticketsSet);
        void Delete(TicketsSet _ticketsSet);
        void Update(TicketsSet _ticketsSet);
        TicketsSet GetMoelById(string id);

        List<TicketsSet> GetAllList();
    }
}
