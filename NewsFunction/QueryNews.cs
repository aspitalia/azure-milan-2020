using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NewsFunction.Services;

namespace NewsFunction
{
    public class QueryNews
    {
        private readonly INewsService _service;

        public QueryNews(INewsService service)
        {
            _service = service;
        }

        [FunctionName("QueryNews")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("QueryNews function processed a request.");

            string q = req.Query["q"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            q = q ?? data?.q;

            var result = await _service.LoadNews(q);

            return new OkObjectResult(result);
        }
    }
}
