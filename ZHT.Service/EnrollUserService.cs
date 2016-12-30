using System.Collections.Generic;
using System.Linq;
using Webdiyer.WebControls.Mvc;
using ZHT.Core.UnitOfWork;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class EnrollUserService : IEnrollUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly  IEnrollUserRepository _enrollUserRepository;
        public EnrollUserService(IUnitOfWork unitOfWork, IEnrollUserRepository enrollUserRepository)
        {
            _unitOfWork = unitOfWork;
            _enrollUserRepository = enrollUserRepository;
        }
        public void Insert(EnrollUser enrollUser)
        {
            _enrollUserRepository.Add(enrollUser);
            _unitOfWork.Commint();
        }

        public void Update(EnrollUser _enrollUser)
        {
            _enrollUserRepository.Update(_enrollUser);
            _unitOfWork.Commint();
        }

        public void Delete(EnrollUser _enrollUser)
        {
            _enrollUserRepository.Delete(_enrollUser);
            _unitOfWork.Commint();
        }

        public EnrollUser GetModelById(string id)
        {
            return _enrollUserRepository.GetById(id);
        }

        public EnrollUser GetModelByPwdNumber(string pwdNumber)
        {
            return _enrollUserRepository.Table.Where(t => t.pwdticket == pwdNumber).FirstOrDefault();               
        }

        public EnrollUser GetModelByOrderNo(string orderNo)
        {
            return _enrollUserRepository.Table.Where(t => t.orderNo == orderNo).FirstOrDefault();
        }


        public List<EnrollUser> GetAllList()
        {
            return _enrollUserRepository.Table.ToList();
        }

        public PagedList<EnrollUser> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string searchKey = null, string status = null)
        {
            var query = _enrollUserRepository.TableAsNoTracking.Where(t => t.exhibitioncode == exhibitionId && t.ticketstatus != -1 && t.isdel == 0);

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
            }

            if (!string.IsNullOrWhiteSpace(status))
            {
                int s = int.Parse(status);
                query = query.Where(t=>t.ticketstatus == s);
            }

            query = query.OrderByDescending(t => t.creattime);

            return query.ToPagedList(pageIndex, pageSize);
        }
        
    }
}
