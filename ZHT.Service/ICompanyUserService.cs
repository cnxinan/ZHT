using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
    public interface ICompanyUserService
    {
        void InsertCompanyUser(CompanyUser companyUser);
        void Update(CompanyUser companyUser);
        void Delete(CompanyUser companyUser);
        CompanyUser GetModelById(string id);
        List<CompanyUser> GetCompanyUserList();
        CompanyUser GetModelByUserCode(string userCode);
    }
}
