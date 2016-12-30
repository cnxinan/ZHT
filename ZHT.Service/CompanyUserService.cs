using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Core.UnitOfWork;
using ZHT.Data.DbFactory;
using ZHT.Data.Models;
using ZHT.Repository;

namespace ZHT.Service
{
    public class CompanyUserService : ICompanyUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyUserRepository _companyUserRepository;

        public CompanyUserService(IUnitOfWork unitOfWork, ICompanyUserRepository companyUserReository)
        {
            _unitOfWork = unitOfWork;
            _companyUserRepository = companyUserReository;
        }

        public List<CompanyUser> GetCompanyUserList()
        {
            var query = _companyUserRepository.Table.ToList();
            return query;
        }

        public void InsertCompanyUser(CompanyUser companyUser)
        {
            _companyUserRepository.Add(companyUser);
            _unitOfWork.Commint();
        }

        public void Update(CompanyUser companyUser)
        {
            _companyUserRepository.Update(companyUser);
            _unitOfWork.Commint();
        }

        public void Delete(CompanyUser companyUser)
        {
            _companyUserRepository.Delete(companyUser);
            _unitOfWork.Commint();
        }

        public CompanyUser GetModelById(string id)
        {
            return _companyUserRepository.GetById(id);
        }

        public CompanyUser GetModelByUserCode(string userCode)
        {
            return _companyUserRepository.Table.Where(t => t.UserID == userCode && t.ValidStatus == true).FirstOrDefault();
        }
    }
}
