using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;


namespace ZHT.Data.DbFactory
{
    public interface IDataBaseFactory :IDisposable
    {
        ZHTDataContext GetDataBase();
    }
}
