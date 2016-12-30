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
    public class FollowMomentService : IFollowMomentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFollowMomentRepository _followMomentRepository;
        public FollowMomentService(IUnitOfWork unitOfWork,IFollowMomentRepository followMomentRepository)
        {
            _unitOfWork = unitOfWork;
            _followMomentRepository = followMomentRepository;
        }
        public void Delete(FollowMoment followMoment)
        {
            _followMomentRepository.Delete(followMoment);
            _unitOfWork.Commint();
        }

        public List<FollowMoment> GetAllList()
        {
            return _followMomentRepository.Table.ToList();
        }

        public FollowMoment GetModelById(string id)
        {
            return _followMomentRepository.GetById(id);
        }

        public void Insert(FollowMoment followMoment)
        {
            _followMomentRepository.Add(followMoment);
            _unitOfWork.Commint();
        }

        public void Update(FollowMoment followMoment)
        {
            _followMomentRepository.Update(followMoment);
            _unitOfWork.Commint();
        }

        public FollowMoment GetModelByMomentIdAndUserId(string momentId, string userId)
        {
            return _followMomentRepository.Table.Where(t => t.momentcode == momentId && t.followusercode == userId).FirstOrDefault();
        }
    }
}
