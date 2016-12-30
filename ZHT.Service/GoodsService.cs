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
    public class GoodsService : IGoodsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IGoodsRepository _goodsRepository;
        private readonly IGoods_MaterialRepository _goods_MaterialRepository;
        private readonly IMaterialRepository _materialRepository;
        public GoodsService(IUnitOfWork unitOfWork, IGoodsRepository goodsRepository, IGoods_MaterialRepository goods_MaterialRepository, IMaterialRepository materialRepository)
        {
            _unitOfWork = unitOfWork;
            _goodsRepository = goodsRepository;
            _goods_MaterialRepository = goods_MaterialRepository;
            _materialRepository = materialRepository;
        }
        public void Delete(Goods goods)
        {
            _goodsRepository.Delete(goods);
            _unitOfWork.Commint();
        }

        public Goods GetModelById(string id)
        {
            return _goodsRepository.GetById(id);
        }

        public void InsertBaseTypes(Goods goods)
        {
            _goodsRepository.Add(goods);
            _unitOfWork.Commint();
        }

        public void Update(Goods goods)
        {
            _goodsRepository.Update(goods);
            _unitOfWork.Commint();
        }

        public List<Goods> GetAllList()
        {
            return _goodsRepository.Table.ToList();
        }

        public List<Goods> GetGoodsByCreator(string creator)
        {
            return _goodsRepository.Table.Where(t => t.sellerCode == creator).ToList();
        }

        public string GetGoodHeadImg(string goodsCode, string serviceUrl)
        {
            var goodsMaterial = _goods_MaterialRepository.Table.Where(t => t.GoodsCode == goodsCode && t.ValidStatus == true).OrderByDescending(t => t.CreateTime).FirstOrDefault();

            if (goodsMaterial != null)
            {
                var material = _materialRepository.Table.Where(t => t.Code == goodsMaterial.GoodsCode).FirstOrDefault();
                if (material != null)
                {
                    return serviceUrl + material.MaterialName;
                }
            }

            return string.Empty;
        }

        public List<string> GetGoodsImgs(string goodsCode, string serviceUrl)
        {
            List<string> result = new List<string>();

            var goodsMaterial = _goods_MaterialRepository.Table.Where(t => t.GoodsCode == goodsCode && t.ValidStatus == true).OrderByDescending(t => t.CreateTime);

            if (goodsMaterial != null && goodsMaterial.Count() > 0)
            {
                foreach (var item in goodsMaterial)
                {
                    var material = _materialRepository.Table.Where(t => t.Code == item.GoodsCode).FirstOrDefault();
                    if (material != null)
                    {
                        result.Add(serviceUrl + material.MaterialName);
                    }
                }
            }

            return result;
        }
    }
}
