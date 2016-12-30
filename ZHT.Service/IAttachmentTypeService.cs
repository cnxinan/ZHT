using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
    public interface IAttachmentTypeService
    {
        void InsertAttachmentType(AttachmentType attachmentType);
        void Update(AttachmentType attachmentType);
        void Delete(AttachmentType attachmentType);
        AttachmentType GetModelById(string id);
        List<AttachmentType> GetAttachmentTypeList();

    }
}
