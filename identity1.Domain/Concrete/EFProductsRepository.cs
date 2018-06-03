using System;
using System.Collections.Generic;
using identity1.Domain.Abstract;
using identity1.Domain.Entities;

namespace identity1.Domain.Concrete
{
    public class EFProductsRepository:IProductsRepository
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();
        public IEnumerable<Product> GetProducts => DbContext.Products;
        
    }
}

