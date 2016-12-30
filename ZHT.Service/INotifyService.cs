using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
    public interface INotifyService
    {
        void Insert(Notify notify);
        void Delete(Notify notify);
        void Update(Notify notify);
        Notify GetModelById(string id);
        List<Notify> GetAllList();
    }
}
