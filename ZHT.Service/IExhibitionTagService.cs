using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
   public interface IExhibitionTagService
    {
        void InsertExhitionTag(ExhibitionTag exhitionTag);
        void Delete(ExhibitionTag exhitionTag);
        void Update(ExhibitionTag exhitionTag);
        ExhibitionTag GetModelById(string id);
        List<ExhibitionTag> GetExhibitionTagList();
    }
}
