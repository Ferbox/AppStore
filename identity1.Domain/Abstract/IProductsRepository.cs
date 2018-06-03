using System.Collections.Generic;
using identity1.Domain.Entities;

namespace identity1.Domain.Abstract
{
    public interface IProductsRepository
    {
        IEnumerable<Product> GetProducts { get; }
    }
}
