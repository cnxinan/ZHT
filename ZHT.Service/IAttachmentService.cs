using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
    public interface IAttachmentService
    {
        void InsertAttachment(Attachment attachment);
        void Update(Attachment attachment);
        void Delete(Attachment attachment);
        Attachment GetModelById(string id);
        List<Attachment> GetAttachmentList();
        List<Attachment> GetListByResourceIdAndType(string resourceId, string typeCode);
    }
}
