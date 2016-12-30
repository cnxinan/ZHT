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
    public class BusinessScopeService : IBusinessScopeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IBusinessScopeRepository _businessScopeRepository;
        public BusinessScopeService(IUnitOfWork unitOfWork, IBusinessScopeRepository businessScopeRepository)
        {
            _unitOfWork = unitOfWork;
            _businessScopeRepository = businessScopeRepository;
        }
        public void Delete(BusinessScope businessScope)
        {
            _businessScopeRepository.Delete(businessScope);
            _unitOfWork.Commint();
        }


        public BusinessScope GetModelById(string id)
        {
            return _businessScopeRepository.GetById(id);
        }

        public void InsertBaseTypes(BusinessScope businessScope)
        {
            _businessScopeRepository.Add(businessScope);
            _unitOfWork.Commint();
        }

        public void Update(BusinessScope businessScope)
        {
            _businessScopeRepository.Update(businessScope);
            _unitOfWork.Commint();
        }

        public List<BusinessScope> GetAllList()
        {
            return _businessScopeRepository.Table.ToList();
        }
    }
}
