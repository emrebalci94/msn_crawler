using MsnCrawler.Business.DataAccess.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Test.Mocks
{
    public class CompanyRepository 
    {
        private readonly ICompanyServices _companyService;
        public CompanyRepository(ICompanyServices companyServices)
        {
            _companyService = companyServices;
        }
        
        public IList<MsnCrawler.Domain.Company> GetCompanies()
        {
            return _companyService.GetCompanies();
        }

        public int InsertOrId(string companyName)
        {
            return _companyService.InsertOrId(companyName);
        }
    }
}
