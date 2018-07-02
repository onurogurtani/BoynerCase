using System.Threading.Tasks;
using BoynerCase.Mongo.Entity;
using MongoDB.Driver;

namespace BoynerCase.Mongo.Repository
{
    public class ProductRepository : IProductRepository
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Product> productsCollection;

        public ProductRepository(string connectionString)
        {
            client = new MongoClient(connectionString);
            database = client.GetDatabase("blog");
            productsCollection = database.GetCollection<Product>("products");
        }

        /*public ProductRepository(IMongoCollection<Product> productsCollection){
            this.productsCollection = productsCollection;
        }*/

        public async Task InsertProduct(Product product)
        {
            await productsCollection.InsertOneAsync(product);
        }

        public async Task<Product> GetProductById(int id)
        {
            var filter = Builders<Product>.Filter.Eq("id", id);
            var result = await productsCollection.Find(filter).FirstOrDefaultAsync();

            return result;
        }

    }
}
