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
    public class ExhibitionProductService : IExhibitionProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IExhibitionProductRepository _exhibitionProductRepository;
        public ExhibitionProductService(IUnitOfWork unitOfWork, IExhibitionProductRepository exhibitionProductRepository)
        {
            _unitOfWork = unitOfWork;
            _exhibitionProductRepository = exhibitionProductRepository;
        }
        public void Delete(ExhibitionProduct exhibitionProduct)
        {
            _exhibitionProductRepository.Delete(exhibitionProduct);
            _unitOfWork.Commint();
        }

        public List<ExhibitionProduct> GetAllList()
        {
            return _exhibitionProductRepository.Table.ToList();
        }

        public ExhibitionProduct GetModelById(string id)
        {
            return _exhibitionProductRepository.GetById(id);
        }

        public void Insert(ExhibitionProduct exhibitionProduct)
        {
            _exhibitionProductRepository.Add(exhibitionProduct);
            _unitOfWork.Commint();
        }

        public void Update(ExhibitionProduct exhibitionProduct)
        {
            _exhibitionProductRepository.Update(exhibitionProduct);
            _unitOfWork.Commint();
        }

        public PagedList<ExhibitionProduct> GetListPageByExhibitionId(string exhibitionId, int pageIndex, int pageSize, string searchKey = null)
        {
            var query = _exhibitionProductRepository.TableAsNoTracking.Where(t=>t.exhibitioncode == exhibitionId);

            if (!string.IsNullOrWhiteSpace(searchKey))
            {
                query = query.Where(t=>t.productName.Contains(searchKey));
            }

            query = query.OrderByDescending(t=>t.creattime);

            return query.ToPagedList<ExhibitionProduct>(pageIndex, pageSize);
        }

        public ExhibitionProduct GetModelByExhibitionIdAndPId(string exhibitionId, string yxProductCode)
        {
            var query = _exhibitionProductRepository.TableAsNoTracking.Where(t => t.exhibitioncode == exhibitionId && t.yxproductcode == yxProductCode);

            return query.FirstOrDefault();
        }
    }
}
