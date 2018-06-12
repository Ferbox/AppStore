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
        public IEnumerable<Product> GetProducts(int[] prodInCart)
        {
            var products = productDao.GetProducts(prodInCart);
            return products;
        }
        IEnumerable<Product> IProductLogic.GetProducts(int type)
        {
            IEnumerable<Product> products = productDao.GetProducts(type);
            return products;
        }
        public void CreateOrder(Order order, string id, int[] orderlist, int[] qty)
        {
            productDao.CreateOrder(order, id, orderlist, qty);
        }
    }
}
