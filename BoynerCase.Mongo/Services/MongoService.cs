using Boyner.DTO.Product;
using BoynerCase.Mongo.Entity;
using BoynerCase.Mongo.Repository;
using EasyNetQ;
using MongoDB.Bson;

namespace BoynerCase.Mongo.Services
{
    public class MongoService : IMongoService
    {
        readonly IBus bus;
        readonly IProductRepository productRepository;
        public MongoService()
        {
            bus = RabbitHutch.CreateBus("host=rabbitmq;username=guest;password=guest");
            productRepository = new ProductRepository("mongodb://mongo/");
        }

        public MongoService(IBus bus,IProductRepository productRepository)
        {
            this.bus = bus;
            this.productRepository = productRepository;
        }

        public void MongoGetConsume()
        {
            bus.Respond<string, ProductModel>(request => GetProduct(int.Parse(request)));
        }

        public void MongoSaveConsume()
        {
            bus.Subscribe<ProductModel>("insertproduct", InsertProduct, x => x.WithTopic("mongo.*"));
        }

        ProductModel GetProduct(int id)
        {
            /* var data = productRepository.GetProductById(id).Result;*/
            /* return data != null? new ProductModel { Id = data.Id, Brand = data.Brand, Details = data.Details, Name = data.Name, Price = data.Price } : new ProductModel();*/
            return new ProductModel { Id = id };
        }

        void InsertProduct(ProductModel model)
        {
           /* var product = new Product { RecordId = ObjectId.GenerateNewId(), Id = model.Id, Brand = model.Brand, Details = model.Details, Name = model.Name, Price = model.Price };
            productRepository.InsertProduct(product);*/
        }
    }
}
