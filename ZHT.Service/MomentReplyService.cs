using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Core.UnitOfWork;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class MomentReplyService : IMomentReplyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMomentReplyRepository _momentReplyRepository;
        public MomentReplyService(IUnitOfWork unitOfWork, IMomentReplyRepository momentReplyRepository)
        {
            _unitOfWork = unitOfWork;
            _momentReplyRepository = momentReplyRepository;
        }
        public void Delete(MomentReply momentReply)
        {
            _momentReplyRepository.Delete(momentReply);
            _unitOfWork.Commint();
        }

        public List<MomentReply> GetAllList()
        {
            return _momentReplyRepository.Table.ToList();
        }

        public MomentReply GetModelById(string id)
        {
            return _momentReplyRepository.GetById(id);
        }

        public void Insert(MomentReply momentReply)
        {
            _momentReplyRepository.Add(momentReply);
            _unitOfWork.Commint();
        }

        public void Update(MomentReply momentReply)
        {
            _momentReplyRepository.Update(momentReply);
            _unitOfWork.Commint();
        }
    }
}
