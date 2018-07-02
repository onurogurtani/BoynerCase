using Autofac;
using EasyNetQ;
using Microsoft.Extensions.Configuration;
namespace BoynerCase.Api.Product
{
    public class AutofacModule : Module
    {
        public IConfiguration Configuration { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => RabbitHutch.CreateBus("host=rabbitmq;username=guest;password=guest")).As<IBus>().SingleInstance();
        }
    }
}
