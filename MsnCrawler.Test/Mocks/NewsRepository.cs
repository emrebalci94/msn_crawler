using MsnCrawler.Business.DataAccess.Services;
using MsnCrawler.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Test.Mocks
{
    public class NewsRepository
    {
        public INewsServices NewsServices { get; }
        public NewsRepository(INewsServices newsServices)
        {
            NewsServices = newsServices;
        }

       public int InsertOrUpdateCount(string title, int companyId)
        {
            return NewsServices.InsertOrUpdateCount(title, companyId);
        }

      public  IList<CompanyCountModel> GetCompanyCounts()
        {
            return NewsServices.GetCompanyCounts();
        }

    }
}
