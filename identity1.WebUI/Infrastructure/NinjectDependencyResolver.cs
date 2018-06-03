using System.Collections.Generic;
using System.Web.Mvc;
using identity1.Domain.Abstract;
using identity1.Domain.Concrete;
using identity1.Domain.Entities;
using Moq;
using Ninject;

namespace GameStore.WebUI.Infrastructure
{
    public class NinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }

        public object GetService(System.Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(System.Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        private void AddBindings()
        {
            //kernel.Bind<IProductsRepository>().To<EFProductsRepository>();
            kernel.Bind<IOrderRepository>().To<EFOrderRepository>();
            ////FOR PASHA

            Mock<IProductsRepository> mock = new Mock<IProductsRepository>();
            mock.Setup(m => m.GetProducts).Returns(new List<Product>
            {
                new Product { ProductId = 1, Title = "iPhone X", Description = "Last model", CostProduct = 999, TypeId = 1 },
                new Product { ProductId = 2, Title = "iMac", Description = "Last model", CostProduct = 899, TypeId = 2 },
                new Product { ProductId = 3, Title = "MacBook", Description = "Last model", CostProduct = 799, TypeId = 3 },
                new Product { ProductId = 4, Title = "iPhone 8", Description = "Last model", CostProduct = 999, TypeId = 1 },
                new Product { ProductId = 5, Title = "iPad", Description = "Last model", CostProduct = 899, TypeId = 4 },
                new Product { ProductId = 6, Title = "MacBook Pro", Description = "Last model", CostProduct = 799, TypeId = 3 },
                new Product { ProductId = 7, Title = "iPhone 7", Description = "Last model", CostProduct = 999, TypeId = 1 },
                new Product { ProductId = 8, Title = "iPad Pro", Description = "Last model", CostProduct = 899, TypeId = 2 },
                new Product { ProductId = 9, Title = "iPhone 6s", Description = "Last model", CostProduct = 799, TypeId = 1 },
                new Product { ProductId = 10, Title = "iPhone 5s", Description = "Last model", CostProduct = 999, TypeId = 1 },
                new Product { ProductId = 11, Title = "iPad(2018)", Description = "Last model", CostProduct = 899, TypeId = 4 },
                new Product { ProductId = 12, Title = "MacBook Air", Description = "Last model", CostProduct = 799, TypeId = 3 },
                new Product { ProductId = 13, Title = "iPhone 4", Description = "Last model", CostProduct = 999, TypeId = 1 },
                new Product { ProductId = 14, Title = "iPad Air", Description = "Last model", CostProduct = 899, TypeId = 4 },
                new Product { ProductId = 15, Title = "MacBook Pro Bar", Description = "Last model", CostProduct = 799, TypeId = 3 },
                new Product { ProductId = 16, Title = "iPhone 7 Plus", Description = "Last model", CostProduct = 999, TypeId = 1 },
                new Product { ProductId = 17, Title = "iPad Pro 12.9", Description = "Last model", CostProduct = 899, TypeId = 2 },
                new Product { ProductId = 18, Title = "iPhone 6s Plus", Description = "Last model", CostProduct = 799, TypeId = 1 }
            });
            kernel.Bind<IProductsRepository>().ToConstant(mock.Object);
        }
    }
}
