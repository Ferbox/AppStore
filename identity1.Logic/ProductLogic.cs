using System;
using System.Linq;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.LogicContracts;
using identity1.Common.Models.ViewModels;


namespace identity1.Logic
{
    public class ProductLogic:IProductLogic
    {
        private readonly IProductDao productDao;

        public ProductLogic(IProductDao _productDao)
        {
            productDao = _productDao;
        }
        public Product GetProduct(int id)
        {
            var product = productDao.GetProduct(id);
            return product;
        }
        public IEnumerable<Product> GetProductForCart(int[] prodInCart)
        {
            var products = productDao.GetProductsForCart(prodInCart);
            return products;
        }


        IEnumerable<Product> IProductLogic.GetProductsForCatalog(int type)
        {
            IEnumerable<Product> products = productDao.GetProductsForCatalog(type);
            return products;
        }
    }
}
