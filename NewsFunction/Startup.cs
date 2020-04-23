using System;
using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using NewsFunction.Services;

[assembly: FunctionsStartup(typeof(NewsFunction.Startup))]

namespace NewsFunction
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {
            builder.Services.AddTransient<INewsService, NewsAPIService>();
        }
    }
}