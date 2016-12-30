using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZHT.Data.Models;

namespace ZHT.Service
{
    public interface ICompanyService
    {
        void InsertCompany(Company company);
        void Update(Company company);
        void Delete(Company company);
        Company GetModelById(string id);
        List<Company> GetCompanyList();
        string GetHeadImg(string companyCode);
        string GetCompanyName(string companyCode);
    }
}
