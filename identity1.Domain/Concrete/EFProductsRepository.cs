using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using identity1.Domain.Abstract;
using identity1.Domain.Entities;

namespace identity1.Domain.Concrete
{
    public class EFProductsRepository:IProductsRepository
    {
        ApplicationDbContext DbContext = new ApplicationDbContext();
        public IEnumerable<Product> GetProducts
        {
            get { return DbContext.Products; }
        }
    }
}
