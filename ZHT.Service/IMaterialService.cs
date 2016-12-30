using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IMaterialService
    {
        void InsertBaseTypes(Material Material);
        void Update(Material Material);
        void Delete(Material Material);
        Material GetModelById(string id);
        List<Material> GetAllList();
    }
}
