using System.Threading.Tasks;
using BoynerCase.Mongo.Entity;
using BoynerCase.Mongo.Repository;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Driver;
using Moq;

namespace BoynerCase.Test.Mongo
{
    [TestClass]
    public class ProductRepositoryTest
    {
        /*
        private readonly ProductRepository productRepository;
        private readonly Mock<IMongoCollection<Product>> productsCollection;

        [TestInitialize]
        public void Setup()
        {
            productsCollection = new Mock<IMongoCollection<Product>>(MockBehavior.Strict);
            productRepository = new ProductRepository(productsCollection.Object);
        }

        [TestMethod]
        public void InsertProductSuccess()
        {
            productsCollection.Setup(w => w.InsertOneAsync(It.IsAny<Product>())).Returns(new Task(true));
            var result = productRepository.InsertProduct(new Product { Id = 1, Name = "test", Price = 100, Details = "testdetil", Brand = "testbrand", RecordId = ObjectId.GenerateNewId() });
            Assert.IsInstanceOfType(result, typeof(Task));
        }

        [TestMethod]
        public void GetProductByIdSuccess(){
            productsCollection.Setup(w => w.Find(It.IsAny<FilterDefinition<Product>>())).Returns();
            var result = productRepository.GetProductById(int.MinValue);
            Assert.IsInstanceOfType(result, typeof(Task<Product>));
        }*/
    }
}
