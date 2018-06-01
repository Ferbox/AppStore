using identity1.Domain.Entities;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using identity1.Controllers;

namespace identity1.UnitTest
{
      [TestClass]
        public class UnitTest1
        {
            [TestMethod]
            public void Can_Paginate()
            {
                // Организация (arrange)
                Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
                mock.Setup(m => m.).Returns(new List<Product>
            {
                new Product { },
                new Product { },
                new Product { },
                new Product { },
                new Product { }
            });
                ProductsController controller = new ProductsController(mock.Object);
                
                // Действие (act)
                IEnumerable<Product> result = (IEnumerable<Product>)controller.Index(2).Model;

                // Утверждение (assert)
                List<Game> games = result.ToList();
                Assert.IsTrue(games.Count == 2);
                Assert.AreEqual(games[0].Name, "Игра4");
                Assert.AreEqual(games[1].Name, "Игра5");
            }
        }
    
}
 