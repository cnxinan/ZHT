using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Core.UnitOfWork;
using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class AttachmentService : IAttachmentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttachmentRepository _attachmentRepository;

        public AttachmentService(IUnitOfWork unitOfWork, IAttachmentRepository attachmentReository)
        {
            _unitOfWork = unitOfWork;
            _attachmentRepository = attachmentReository;
        }

        public List<Attachment> GetAttachmentList()
        {
            var query = _attachmentRepository.Table.ToList();
            return query;
        }

        public void InsertAttachment(Attachment attachment)
        {
            _attachmentRepository.Add(attachment);
            _unitOfWork.Commint();
        }

        public void Update(Attachment attachment)
        {
            _attachmentRepository.Update(attachment);
            _unitOfWork.Commint();
        }

        public void Delete(Attachment attachment)
        {
            _attachmentRepository.Delete(attachment);
            _unitOfWork.Commint();
        }

        public Attachment GetModelById(string id)
        {
            return _attachmentRepository.GetById(id);
        }

        public List<Attachment> GetListByResourceIdAndType(string resourceId,string typeCode)
        {
            var query = _attachmentRepository.TableAsNoTracking.Where(t => t.ResourceID == resourceId && t.AttachmentTypeCode == typeCode);

            return query.ToList();
        }
    }
}
