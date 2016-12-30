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
    public class Goods_BusinessScopeTypeService : IGoods_BusinessScopeTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoods_BusinessScopeTypeRepository _goods_BusinessScopeTypeRepository;
        public Goods_BusinessScopeTypeService(IUnitOfWork unitOfWork, IGoods_BusinessScopeTypeRepository goods_BusinessScopeTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _goods_BusinessScopeTypeRepository = goods_BusinessScopeTypeRepository;
        }
        public void Delete(Goods_BusinessScopeType goods_BusinessScopeType)
        {
            _goods_BusinessScopeTypeRepository.Delete(goods_BusinessScopeType);
            _unitOfWork.Commint();
        }


        public Goods_BusinessScopeType GetModelById(string id)
        {
            return _goods_BusinessScopeTypeRepository.GetById(id);
        }

        public void InsertBaseTypes(Goods_BusinessScopeType goods_BusinessScopeType)
        {
            _goods_BusinessScopeTypeRepository.Add(goods_BusinessScopeType);
            _unitOfWork.Commint();
        }

        public void Update(Goods_BusinessScopeType goods_BusinessScopeType)
        {
            _goods_BusinessScopeTypeRepository.Update(goods_BusinessScopeType);
            _unitOfWork.Commint();
        }

        public List<Goods_BusinessScopeType> GetAllList()
        {
            return _goods_BusinessScopeTypeRepository.Table.ToList();
        }
    }
}
