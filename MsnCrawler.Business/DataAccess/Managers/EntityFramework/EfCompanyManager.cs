using MsnCrawler.Business.DataAccess.Services;
using MsnCrawler.Common.DataAccess;
using MsnCrawler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Business.DataAccess.Managers.EntityFramework
{
    public class EfCompanyManager : ICompanyServices
    {
        private readonly IRepository<Company> _repository;

        public EfCompanyManager(IRepository<Company> repository)
        {
            _repository = repository;
        }
        public IList<Company> GetCompanies()
        {
            return _repository.GetList();
        }

       
        public int InsertOrId(string companyName)
        {
            Company company = _repository.Get(p => p.Name == companyName);
            if (company == null)
            {

                int result = _repository.Insert(new Company
                {
                    Name = companyName,
                    CreatedAt = DateTime.Now,
                    UpdateAt = DateTime.Now,
                    Deleted = false,
                });
                if (result > 0)
                {
                    return _repository.Get(p => p.Name == companyName).Id;
                }
                return result;
            }
            else
            {
                return company.Id;
            }
        }
    }
}
