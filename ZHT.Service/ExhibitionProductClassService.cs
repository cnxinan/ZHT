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
    public class ExhibitionProductClassService : IExhibitionProductClassService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExhibitionProductClassRepository _exhibitionProductClassRepository;
        public ExhibitionProductClassService(IUnitOfWork unitOfWork, IExhibitionProductClassRepository exhibitionProductClassRepository)
        {
            _unitOfWork = unitOfWork;
            _exhibitionProductClassRepository = exhibitionProductClassRepository;
        }
        public void Delete(ExhibitionProductClass exhibitionProductClass)
        {
            _exhibitionProductClassRepository.Delete(exhibitionProductClass);
            _unitOfWork.Commint();
        }

        public List<ExhibitionProductClass> GetAllList()
        {
            return _exhibitionProductClassRepository.Table.ToList();
        }

        public ExhibitionProductClass GetModelById(string id)
        {
            return _exhibitionProductClassRepository.GetById(id);
        }

        public void Insert(ExhibitionProductClass exhibitionProductClass)
        {
            _exhibitionProductClassRepository.Add(exhibitionProductClass);
            _unitOfWork.Commint();
        }

        public void Update(ExhibitionProductClass exhibitionProductClass)
        {
            _exhibitionProductClassRepository.Update(exhibitionProductClass);
            _unitOfWork.Commint();
        }

        public PagedList<ExhibitionProductClass> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string searchKey = null)
        {
            var query = _exhibitionProductClassRepository.TableAsNoTracking.Where(p => p.exhibitioncode == exhibitionId);

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                query = query.Where(t => t.classname.Contains(searchKey));
            }

            query = query.OrderByDescending(t => t.creattime);

            return query.ToPagedList(pageIndex, pageSize);
        }

    }
}
