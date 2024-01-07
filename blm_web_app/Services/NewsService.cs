// Services/NewsService.cs
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using blm_web_app.Models;

namespace blm_web_app.Services
{
    public class NewsService
    {
        private readonly HttpClient _httpClient;

        public NewsService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<NewsItem>> GetNewsAsync(string apiUrl)
        {
            // API'den haberleri çek
            var response = await _httpClient.GetStringAsync(apiUrl);

            // Cevabı JSON'dan NewsItem listesine dönüştür
            var news = JsonConvert.DeserializeObject<List<NewsItem>>(response);

            return news;
        }
    }
}
