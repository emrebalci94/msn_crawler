using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Mvc;
using MsnCrawler.Business.DataAccess.Services;
using MsnCrawler.UI.Helpers;
using MsnCrawler.UI.Models;

namespace MsnCrawler.UI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICompanyServices _companyServices;
        private readonly INewsServices _newsServices;


        public HomeController(ICompanyServices companyServices, INewsServices newsServices)
        {
            _companyServices = companyServices;
            _newsServices = newsServices;
        }



        public async Task<IActionResult> Index()
        {
            ViewBag.HomeActive = "active";
            var lastNews = await CrawlerHelper.Instance.GetLastNews();
            foreach (var item in lastNews)
            {
                item.Id = _companyServices.InsertOrId(item.SourceName);
                item.SomeCount = _newsServices.InsertOrUpdateCount(item.Title, item.Id);
            }
            return View(lastNews);
        }

        public IActionResult GetCompanyCount()
        {
            return Ok(_newsServices.GetCompanyCounts());
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
