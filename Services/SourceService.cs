using BlogAPI.Models;
using HtmlAgilityPack;
using Microsoft.AspNetCore.Components;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Threading.Tasks.Sources;

namespace BlogAPI.Services
{
    public class SourceService
    {
        private readonly HttpClient _httpClient;
        public SourceService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<Source>> GetSourceElements()
        {
            var url = "https://techcrunch.com/";
            var res = await _httpClient.GetStringAsync(url);

            var document = new HtmlDocument();
            document.LoadHtml(res);

            var articleElements = document.DocumentNode.SelectNodes("//div[contains(@class, 'post-block')]")
                .Select(element => new Source
                 {
                     Article_Headline = element.SelectSingleNode(".//h2/a")?.InnerText.Trim(),
                     Article_Author = element.SelectSingleNode(".//span[contains(@class, 'river-byline__authors')]")?.InnerText.Trim(),
                     Article_URL = element.SelectSingleNode(".//h2/a")?.Attributes["href"].Value
                 });

            return articleElements;
        }
    }
}