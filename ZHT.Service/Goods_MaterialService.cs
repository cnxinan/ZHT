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
    public class Goods_MaterialService : IGoods_MaterialService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoods_MaterialRepository _goods_MaterialRepository;
        public Goods_MaterialService(IUnitOfWork unitOfWork, IGoods_MaterialRepository goods_MaterialRepository)
        {
            _unitOfWork = unitOfWork;
            _goods_MaterialRepository = goods_MaterialRepository;
        }
        public void Delete(Goods_Material goods_Material)
        {
            _goods_MaterialRepository.Delete(goods_Material);
            _unitOfWork.Commint();
        }


        public Goods_Material GetModelById(string id)
        {
            return _goods_MaterialRepository.GetById(id);
        }

        public void InsertBaseTypes(Goods_Material goods_Material)
        {
            _goods_MaterialRepository.Add(goods_Material);
            _unitOfWork.Commint();
        }

        public void Update(Goods_Material goods_Material)
        {
            _goods_MaterialRepository.Update(goods_Material);
            _unitOfWork.Commint();
        }

        public List<Goods_Material> GetAllList()
        {
            return _goods_MaterialRepository.Table.ToList();
        }
    }
}
