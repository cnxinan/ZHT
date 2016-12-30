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
    public class GoodsUnitService : IGoodsUnitService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoodsUnitRepository _goodsUnitRepository;
        public GoodsUnitService(IUnitOfWork unitOfWork, IGoodsUnitRepository goodsUnitRepository)
        {
            _unitOfWork = unitOfWork;
            _goodsUnitRepository = goodsUnitRepository;
        }
        public void Delete(GoodsUnit goodsUnit)
        {
            _goodsUnitRepository.Delete(goodsUnit);
            _unitOfWork.Commint();
        }


        public GoodsUnit GetModelById(string id)
        {
            return _goodsUnitRepository.GetById(id);
        }

        public void InsertBaseTypes(GoodsUnit goodsUnit)
        {
            _goodsUnitRepository.Add(goodsUnit);
            _unitOfWork.Commint();
        }

        public void Update(GoodsUnit goodsUnit)
        {
            _goodsUnitRepository.Update(goodsUnit);
            _unitOfWork.Commint();
        }

        public List<GoodsUnit> GetAllList()
        {
            return _goodsUnitRepository.Table.ToList();
        }
    }
}
