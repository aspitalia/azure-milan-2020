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
    public class Headlines
    {
        private readonly INewsService _service;

        public Headlines(INewsService service)
        {
            _service = service;
        }

        [FunctionName("Headlines")]
        public async Task<IActionResult> Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req, ILogger log)
        {
            log.LogInformation("Headlines function processed a request.");

            string q = req.Query["q"];

            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            q = q ?? data?.q;

            //var result = await _service.LoadHeadlines(q);

            //return new OkObjectResult(result);

            return null;
        }
    }
}
