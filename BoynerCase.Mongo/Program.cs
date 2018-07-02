using BoynerCase.Mongo.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace BoynerCase.Mongo
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var serviceProvider = ConfigureServices();
            var mongoService = serviceProvider.GetService<IMongoService>();

            mongoService.MongoSaveConsume();
            mongoService.MongoGetConsume();
        }

        static ServiceProvider ConfigureServices()
        {
            var services = new ServiceCollection();
            services.AddOptions();
            services.AddSingleton<IMongoService, MongoService>();
            return services.BuildServiceProvider();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
