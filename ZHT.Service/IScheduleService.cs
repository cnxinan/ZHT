using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IScheduleService
    {
        void InsertSchedule(Schedule _schedule);
        void Delete(Schedule _schedule);
        void Update(Schedule _schedule);
        Schedule GetModelById(string id);

        List<Schedule> GetAllList();
    }
}
