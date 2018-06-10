using System;
using System.Collections.Generic;
using identity1.Common.Entities;
using identity1.DALContracts;
using identity1.LogicContracts;

namespace identity1.Logic
{
    public class ProductLogic:IProductLogic
    {
        enum SizeBodyWatch
        {
            _38mm = 1,
            _42mm = 2
        }
        enum MemberSize
        {
            _16gb = 1,
            _32gb = 2,
            _64gb = 3,
            _128gb = 4,
            _256gb = 5,
            _512gb = 6
        }
        enum Color
        {
            red = 1,
            spacegray = 2,
            silver = 3,
            rose = 4,
            rosegold = 5
        }
        private readonly IProductDao productDao;

        public ProductLogic(IProductDao _productDao)
        {
            productDao = _productDao;
        }
        public Product GetProduct(int id) => throw new NotImplementedException();
        public IEnumerable<Product> GetProductForBasket(int[] prodInBasket) => throw new NotImplementedException();


        IEnumerable<Product> IProductLogic.GetProductsForCatalog(int type)
        {
            var products = productDao.GetProducts(type);
            return products;

        }
    }
}
