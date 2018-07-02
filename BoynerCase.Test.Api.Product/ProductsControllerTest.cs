using System.Collections.Generic;
using System.Threading.Tasks;
using Boyner.DTO.Product;
using BoynerCase.Api.Product.Controllers;
using EasyNetQ;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace BoynerCase.Test.Api.Product
{
    [TestClass]
    public class ProductsControllerTest
    {
        private ProductsController productsController;
        private Mock<IBus> bus;
        [TestInitialize]
        public void Setup()
        {
            bus = new Mock<IBus>(MockBehavior.Strict);
            productsController = new ProductsController(bus.Object);
        }

        [TestMethod]
        public void GetByIdSuccessTest()
        {   
            bus.Setup(w => w.RequestAsync<string, ProductModel>(It.IsAny<string>())).Returns(Task.FromResult(new ProductModel()));
            var result = productsController.Get(123);
            Assert.IsInstanceOfType(result, typeof(Task<ActionResult>));

        }

        [TestMethod]
        public void GetByQuerySuccessTest()
        {
            bus.Setup(w => w.RequestAsync<string, List<ProductModel>>(It.IsAny<string>())).Returns(Task.FromResult(new List<ProductModel>()));
            var result = productsController.Get("newQuery");
            Assert.IsInstanceOfType(result, typeof(Task<ActionResult>));
        }

        [TestMethod]
        public void PostProductModelSuccessTest(){
            bus.Setup(w => w.Publish(It.IsAny<ProductModel>(), It.IsAny<System.Action<EasyNetQ.FluentConfiguration.IPublishConfiguration>>()));
            var result = productsController.Post(new ProductModel());
            Assert.IsInstanceOfType(result, typeof(ActionResult));
        }
    }
}
