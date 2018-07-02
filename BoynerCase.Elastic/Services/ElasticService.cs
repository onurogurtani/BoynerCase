using System;
using System.Collections.Generic;
using Boyner.DTO.Product;
using EasyNetQ;
using Nest;

namespace BoynerCase.Elastic.Services
{
    public class ElasticService : IElasticService
    {
        readonly IBus bus;
        readonly IElasticClient client;
        public ElasticService()
        {
            bus = RabbitHutch.CreateBus("host=rabbitmq;username=guest;password=guest");

           /* var indexSettings = new IndexSettings();
            indexSettings.NumberOfReplicas = 1;
            indexSettings.NumberOfShards = 1;
            var createIndexDescriptor = new CreateIndexDescriptor("products").Mappings(ms => ms.Map<ProductModel>(m => m.AutoMap()))
            .InitializeUsing(new IndexState() { Settings = indexSettings }).Aliases(a => a.Alias("bora_blog"));
            var node = new Uri("elastic");
            var  settings = new ConnectionSettings(node);
            client = new ElasticClient(settings);
            client.CreateIndex(createIndexDescriptor);
            */
        }

        /*public ElasticService(IBus bus, IElasticClient client)
        {
            this.bus = bus;
            this.client = client;
        }*/

        public void ElasticQueryConsume()
        {
            bus.Respond<string, List<ProductModel>>(request => GetQueryList(request));
        }

        public void ElasticSaveConsume()
        {
            bus.Subscribe<ProductModel>("insertproduct", Insert, x => x.WithTopic("*.elastic"));
        }

        void Insert(ProductModel model)
        {
           //// client.Index<ProductModel>(model, idx => idx.Index("my_blog"));
        }

        List<ProductModel> GetQueryList(string query)
        {
            var retval = new List<ProductModel>();
           //// var data = client.Search<ProductModel>(s => s.Query(q =>q.MatchAll().Accept());
            return retval;
        }
    }
}
