using BoynerCase.Elastic.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BoynerCase.Elastic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var elasticService = serviceProvider.GetService<IElasticService>();

            elasticService.ElasticQueryConsume();
            elasticService.ElasticSaveConsume();
        }
        static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddSingleton<IElasticService, ElasticService>();
            return services.BuildServiceProvider();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
