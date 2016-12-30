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
    public class SettlementService : ISettlementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ISettlementRepository _settlementRepository;
        public SettlementService(IUnitOfWork unitOfWork, ISettlementRepository settlementRepository)
        {
            _unitOfWork = unitOfWork;
            _settlementRepository = settlementRepository;
        }
        public void Delete(Settlement yxProduct)
        {
            _settlementRepository.Delete(yxProduct);
            _unitOfWork.Commint();
        }

        public List<Settlement> GetAllList()
        {
            return _settlementRepository.Table.ToList();
        }

        public Settlement GetModelById(string id)
        {
            return _settlementRepository.GetById(id);
        }

        public void Insert(Settlement yxProduct)
        {
            _settlementRepository.Add(yxProduct);
            _unitOfWork.Commint();
        }

        public void Update(Settlement yxProduct)
        {
            _settlementRepository.Update(yxProduct);
            _unitOfWork.Commint();
        }

        public Settlement GetModelByExhibitionAndType(string exhibitonId, int type)
        {
            var query = _settlementRepository.TableAsNoTracking.Where(t => t.exhibitionCode == exhibitonId && t.type == type);

            return query.FirstOrDefault();
        }

        public PagedList<Settlement> GetPagedList(int pageIndex, int pageSize, string exhibitionName, string type)
        {
            var query = _settlementRepository.TableAsNoTracking;

            if(!string.IsNullOrWhiteSpace(exhibitionName))
            {
                query = query.Where(t => t.exhibition.exhibitionname.Contains(exhibitionName));
            }

            if (!string.IsNullOrWhiteSpace(type))
            {
                int intT = int.Parse(type);
                query = query.Where(t => t.type == intT);
            }

            query = query.OrderByDescending(t=>t.creatTime);
            return query.ToPagedList(pageIndex, pageSize);
        }
    }
}
