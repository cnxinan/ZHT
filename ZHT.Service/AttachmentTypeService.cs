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
    public class AttachmentTypeService : IAttachmentTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAttachmentTypeRepository _attachmentTypeRepository;

        public AttachmentTypeService(IUnitOfWork unitOfWork, IAttachmentTypeRepository attachmentTypeReository)
        {
            _unitOfWork = unitOfWork;
            _attachmentTypeRepository = attachmentTypeReository;
        }

        public List<AttachmentType> GetAttachmentTypeList()
        {
            var query = _attachmentTypeRepository.Table.ToList();
            return query;
        }

        public void InsertAttachmentType(AttachmentType attachmentType)
        {
            _attachmentTypeRepository.Add(attachmentType);
            _unitOfWork.Commint();
        }

        public void Update(AttachmentType attachmentType)
        {
            _attachmentTypeRepository.Update(attachmentType);
            _unitOfWork.Commint();
        }

        public void Delete(AttachmentType attachmentType)
        {
            _attachmentTypeRepository.Delete(attachmentType);
            _unitOfWork.Commint();
        }

        public AttachmentType GetModelById(string id)
        {
            return _attachmentTypeRepository.GetById(id);
        }
    }
}
