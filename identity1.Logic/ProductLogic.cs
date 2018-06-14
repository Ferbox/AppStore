using System;
using System.Linq;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.LogicContracts;
using identity1.Common.Models.ViewModels;
using System.Threading.Tasks;

namespace identity1.Logic
{
    public class ProductLogic:IProductLogic
    {
        private readonly IProductDao productDao;

        public ProductLogic(IProductDao _productDao)
        {
            productDao = _productDao;
        }
        public async Task<Product> GetProduct(int id)
        {
            var product = productDao.GetProduct(id);
            return await product;
        }
        public IEnumerable<Product> GetProducts(int[] prodInCart)
        {
            var products = productDao.GetProducts(prodInCart);
            return products;
        }
        public IEnumerable<Product> GetProducts(int type)
        {
            var products = productDao.GetProducts(type).Where(x => x.TypeId == type);
            return products;
        }
        public void CreateOrder(Order order, string id, int[] orderlist, int[] qty)
        {
            productDao.CreateOrder(order, id, orderlist, qty);
        }

        public void CreateProduct(Product product, string[] charak)
        {


        //    productDao.CreateOrder(product);
        }
    }
}
