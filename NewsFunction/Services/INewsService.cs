using NewsFunction.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NewsFunction.Services
{
    public interface INewsService
    {
        Task<List<Article>> LoadNews(string q);
    }
}
