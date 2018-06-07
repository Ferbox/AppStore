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
        }
    }
}
