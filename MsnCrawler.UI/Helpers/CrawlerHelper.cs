using HtmlAgilityPack;
using MsnCrawler.UI.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace MsnCrawler.UI.Helpers
{
    public class CrawlerHelper
    {
        private readonly HttpClient _httpClient;
        private CrawlerHelper()
        {
            _httpClient = new HttpClient();
        }

        private static Lazy<CrawlerHelper> _crawlerHelper = new Lazy<CrawlerHelper>(() => new CrawlerHelper(), LazyThreadSafetyMode.ExecutionAndPublication);
        public static CrawlerHelper Instance
        {
            get
            {
                return _crawlerHelper.Value;
            }
        }

        public async Task<List<NewsModel>> GetLastNews()
        {
            string html = await GetResponse("https://www.msn.com/tr-tr");

            HtmlDocument htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(html);
            var htmlNodes = htmlDocument.DocumentNode.SelectNodes("//body/div/div[contains(@id,'maincontent')]/div/main/div[contains(@class,'todaystripe')]/div/div/ul/li");
            List<NewsModel> models = new List<NewsModel>();
            foreach (var item in htmlNodes)
            {
                string source = System.Net.WebUtility.HtmlDecode(item.SelectSingleNode("a/div/div/span[contains(@class,'sourcename')]").InnerText).Trim();
                string title = System.Net.WebUtility.HtmlDecode(item.SelectSingleNode("a/div/p").InnerText);
                string link = "https://www.msn.com" + item.SelectSingleNode("a").Attributes["href"].Value;
                models.Add(new NewsModel
                {
                    Title = title,
                    SourceName = source,
                    DetailLink=link
                });

            }

            return models;
        }

        private async Task<string> GetResponse(string url)
        {
            using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri(url)))
            {
                request.Headers.TryAddWithoutValidation("Accept", "text/html,application/xhtml+xml,application/xml");
                request.Headers.TryAddWithoutValidation("Accept-Encoding", "gzip, deflate");
                //request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Windows NT 6.2; WOW64; rv:19.0) Gecko/20100101 Firefox/19.0");
                request.Headers.TryAddWithoutValidation("User-Agent", "Mozilla/5.0 (Linux; Android 6.0; Nexus 5 Build/MRA58N) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/61.0.3163.100 Mobile Safari/537.36");

                request.Headers.TryAddWithoutValidation("Accept-Charset", "ISO-8859-9");

                using (var response = await _httpClient.SendAsync(request).ConfigureAwait(false))
                {
                    response.EnsureSuccessStatusCode();
                    using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                    using (var decompressedStream = new GZipStream(responseStream, CompressionMode.Decompress))
                    using (var streamReader = new StreamReader(decompressedStream))
                    {
                        return await streamReader.ReadToEndAsync().ConfigureAwait(false);
                    }
                }
            }
        }


    }
}
