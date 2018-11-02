using MsnCrawler.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace MsnCrawler.Business.DataAccess.Services
{
    public interface ICompanyServices
    {
        IList<Company> GetCompanies();
        /// <summary>
        /// Verilen adı veritabanında kontrol eder.Yoksa kaydedip Id'sini döner. Varsa yine id sini döner.
        /// </summary>
        /// <param name="companyName">Haberi yayınlayan kurum.</param>
        /// <returns></returns>
        int InsertOrId(string companyName);
    }
}
