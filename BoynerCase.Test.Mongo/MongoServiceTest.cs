using BoynerCase.Mongo.Repository;
using BoynerCase.Mongo.Services;
using EasyNetQ;
using Moq;

namespace BoynerCase.Test.Mongo
{
    public class MongoServiceTest
    {
        private readonly Mock<IBus> bus;
        private readonly Mock<IProductRepository> productRepository;
        private readonly IMongoService mongoService;

    }
}
