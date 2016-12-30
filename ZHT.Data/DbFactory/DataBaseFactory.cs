using ZHT.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace ZHT.Data.DbFactory
{
    public class DataBaseFactory : IDataBaseFactory
    {
        private ZHTDataContext _context;
        public void Dispose()
        {
            if (_context != null)
                _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public ZHTDataContext GetDataBase()
        {
            return _context ?? (_context = new ZHTDataContext());
        }
    }
}
