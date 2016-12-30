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
    public class BusinessScopeTypeService : IBusinessScopeTypeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusinessScopeTypeRepository _businessScopeTypeRepository;
        public BusinessScopeTypeService(IUnitOfWork unitOfWork, IBusinessScopeTypeRepository businessScopeTypeRepository)
        {
            _unitOfWork = unitOfWork;
            _businessScopeTypeRepository = businessScopeTypeRepository;
        }
        public void Delete(BusinessScopeType businessScopeType)
        {
            _businessScopeTypeRepository.Delete(businessScopeType);
            _unitOfWork.Commint();
        }


        public BusinessScopeType GetModelById(string id)
        {
            return _businessScopeTypeRepository.GetById(id);
        }

        public void InsertBaseTypes(BusinessScopeType businessScopeType)
        {
            _businessScopeTypeRepository.Add(businessScopeType);
            _unitOfWork.Commint();
        }

        public void Update(BusinessScopeType businessScopeType)
        {
            _businessScopeTypeRepository.Update(businessScopeType);
            _unitOfWork.Commint();
        }

        public List<BusinessScopeType> GetAllList()
        {
            return _businessScopeTypeRepository.Table.ToList();
        }
    }
}
