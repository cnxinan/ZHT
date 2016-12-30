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
    public class CompanyService : ICompanyService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ICompanyRepository _companyRepository;
        private readonly IAttachmentRepository _attachmentRepository;

        public CompanyService(IUnitOfWork unitOfWork, ICompanyRepository companyReository, IAttachmentRepository attachmentRepository)
        {
            _unitOfWork = unitOfWork;
            _companyRepository = companyReository;
            _attachmentRepository = attachmentRepository;
        }

        public List<Company> GetCompanyList()
        {
            var query = _companyRepository.Table.ToList();
            return query;
        }

        public void InsertCompany(Company company)
        {
            _companyRepository.Add(company);
            _unitOfWork.Commint();
        }

        public void Update(Company company)
        {
            _companyRepository.Update(company);
            _unitOfWork.Commint();
        }

        public void Delete(Company company)
        {
            _companyRepository.Delete(company);
            _unitOfWork.Commint();
        }

        public Company GetModelById(string id)
        {
            return _companyRepository.GetById(id);
        }

        public string GetHeadImg(string companyCode)
        {
            var company = _companyRepository.Table.Where(t => t.Code == companyCode && t.VersionEndTime.Equals(DateTime.MaxValue)).FirstOrDefault();

            if (company != null)
            {
                var attachment = _attachmentRepository.Table.Where(t => t.AttachmentTypeCode == "6" && t.ResourceID == company.Code).FirstOrDefault();

                if (attachment != null)
                {
                    return attachment.URL;
                }
            }
            return string.Empty;
        }

        public string GetCompanyName(string companyCode)
        {
            var company = _companyRepository.Table.Where(t => t.Code == companyCode && t.VersionEndTime.Equals(DateTime.MaxValue)).FirstOrDefault();

            if (company != null)
            {
                return company.CnName;
            }

            return string.Empty;
        }
    }
}
