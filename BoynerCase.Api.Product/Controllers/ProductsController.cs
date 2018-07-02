using System.Collections.Generic;
using System.Threading.Tasks;
using Boyner.DTO.Product;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;

namespace BoynerCase.Api.Product.Controllers
{
    [Route("api/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IBus bus;
        public ProductsController(IBus bus){
            this.bus = bus;
        }

        // GET: api/values
        [HttpGet]
        public async Task<ActionResult> Get([FromQuery(Name = "query")] string query)
        {
            return await Task.FromResult(Ok(bus.RequestAsync<string, List<ProductModel>>(query)));
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public async Task<ActionResult> Get(int id)
        {
            return await Task.FromResult(Ok(bus.RequestAsync<string, ProductModel>(id.ToString())));
        }

        // POST api/values
        [HttpPost]
        public ActionResult Post([FromBody]ProductModel model)
        {
            bus.Publish(model, x => x.WithTopic("mongo.elastic"));
            bus.Publish(model, x => x.WithTopic("mongo.elastic"));
            return Ok();
        }
    }
}
