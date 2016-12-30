using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Webdiyer.WebControls.Mvc;
using ZHT.Core.UnitOfWork;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class MomentService : IMomentService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMomentRepository _momentRepository;
        public MomentService(IUnitOfWork unitOfWork, IMomentRepository momentRepository)
        {
            _unitOfWork = unitOfWork;
            _momentRepository = momentRepository;
        }
        public void Delete(Moment moment)
        {
            _momentRepository.Delete(moment);
            _unitOfWork.Commint();
        }

        public List<Moment> GetAllList()
        {
            return _momentRepository.Table.ToList();
        }

        public Moment GetModelById(string id)
        {
            return _momentRepository.GetById(id);
        }

        public void Insert(Moment moment)
        {
            _momentRepository.Add(moment);
            _unitOfWork.Commint();
        }

        public void Update(Moment moment)
        {
            _momentRepository.Update(moment);
            _unitOfWork.Commint();
        }

        public List<Moment> GetListByExhibitionId(string exhibitionId)
        {
            var query = _momentRepository.TableAsNoTracking.Where(p => p.exhibitioncode == exhibitionId && p.isdel == 0);

            return query.ToList();
        }

        public List<Moment> GetNoViewdMomentList(string exhibitionId, string loginUserId)
        {
            var query = _momentRepository.TableAsNoTracking.Where(t => t.exhibitioncode == exhibitionId && !t.viewUserIds.Contains(loginUserId));
            
            return query.ToList();
        }

        public PagedList<Moment> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string searchKey = null)
        {
            var query = _momentRepository.TableAsNoTracking.Where(t=>t.exhibitioncode == exhibitionId);

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                query = query.Where(t => t.pubcontent.Contains(searchKey));
            }

            query = query.OrderByDescending(t=>t.creattime);
            return query.ToPagedList(pageIndex, pageSize);
        }

        public int GetNoViewdMomentCount(string exhibitionId, string loginUserId)
        {
            var query = _momentRepository.TableAsNoTracking.Where(t => t.exhibitioncode == exhibitionId && !t.viewUserIds.Contains(loginUserId) && t.isdel != 1);

            return query.Count();
        }
    }
}
