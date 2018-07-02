using System.Threading.Tasks;
using BoynerCase.Mongo.Entity;

namespace BoynerCase.Mongo.Repository
{
    public interface IProductRepository
    {
        Task InsertProduct(Product product);
        Task<Product> GetProductById(int id);
    }
}
