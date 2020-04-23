using NewsFunction.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace NewsFunction.Services
{
    public class NewsAPIService : INewsService
    { 
        public async Task<List<Article>> LoadNews(string q)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://newsapi.org/v2/everything?q={q}&sortBy=popularity&apiKey=cc1d0461e72b4ea58da782c15b775d03");

                if (response.IsSuccessStatusCode)
                {
                    var result = Result.FromJson(await response.Content.ReadAsStringAsync());
                    return result.Articles;
                }
            }

            return null;
        }

        public async Task<List<Article>> LoadHeadlines(string q)
        {
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.GetAsync($"http://newsapi.org/v2/top-headlines?q={q}&apiKey=cc1d0461e72b4ea58da782c15b775d03");

                if (response.IsSuccessStatusCode)
                {
                    var result = Result.FromJson(await response.Content.ReadAsStringAsync());
                    return result.Articles;
                }
            }

            return null;
        }
    }
}
