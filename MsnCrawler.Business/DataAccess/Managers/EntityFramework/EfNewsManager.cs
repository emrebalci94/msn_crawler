using MsnCrawler.Business.DataAccess.Services;
using MsnCrawler.Business.Dto;
using MsnCrawler.Common.DataAccess;
using MsnCrawler.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MsnCrawler.Business.DataAccess.Managers.EntityFramework
{
    public class EfNewsManager : INewsServices
    {
        private readonly IRepository<News> _repository;
        public EfNewsManager(IRepository<News> repository)
        {
            _repository = repository;
        }

        public IList<CompanyCountModel> GetCompanyCounts()
        {
            return _repository.GetQueryable().OrderByDescending(p => p.UpdateAt).GroupBy(p => p.Company.Name).Select(p => new CompanyCountModel { Name = p.Key, Count = p.Count() }).ToList();
        }

        public int InsertOrUpdateCount(string title,int companyId)
        {
            News news = _repository.Get(p => p.Title == title);
            if (news == null)
            {
                News newModel = new News();
                newModel.SameCount = 0;
                newModel.Title = title;
                newModel.Deleted = false;
                newModel.CreatedAt = DateTime.Now;
                newModel.UpdateAt = DateTime.Now;
                newModel.CompanyId = companyId;
                int result= _repository.Insert(newModel);
                if (result >0)
                {
                    return newModel.SameCount;
                }
                return result;
            }
            else
            {
                news.UpdateAt = DateTime.Now;
                news.SameCount++;
                int result = _repository.Update(news);
                if (result > 0)
                {
                    return news.SameCount;
                }
                return result;
            }
        }
    }
}
