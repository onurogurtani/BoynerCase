using System;
namespace BoynerCase.Framework.RabbitMQ
{
    public interface IRabbitConsumeMQ
    {
        void ConsumeMessage();
    }
}
