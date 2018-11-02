using MsnCrawler.Business.Dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Business.DataAccess.Services
{
    public interface INewsServices
    {
        /// <summary>
        /// Haber başlığını ve kurumu alır veritabanında yoksa kaydeder. Varsa SameCount bilgisini geri döner.
        /// </summary>
        /// <param name="title">Haber Başlığı</param>
        /// <param name="companyId">Kurum Id</param>
        /// <returns></returns>
        int InsertOrUpdateCount(string title,int companyId);
        IList<CompanyCountModel> GetCompanyCounts();
    }
}
