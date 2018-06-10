using System.Collections.Generic;
using System.Web.Mvc;
using identity1.DAL.DAO;
using identity1.DALContracts;
using identity1.Logic;
using identity1.LogicContracts;
using Ninject;

namespace identity1.NinjectConfigurator
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
            kernel.Bind<IProductLogic>().To<ProductLogic>().InSingletonScope();
            kernel.Bind<IOrderLogic>().To<OrderLogic>().InSingletonScope();
            kernel.Bind<IOrderDao>().To<OrderDao>().InSingletonScope();
            kernel.Bind<IProductDao>().To<ProductsDao>().InSingletonScope();

        }
    }
}
