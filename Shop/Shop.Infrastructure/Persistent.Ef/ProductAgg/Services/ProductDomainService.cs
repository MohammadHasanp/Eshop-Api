using Shop.Domain.ProductAgg.DomainServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Infrastructure.Persistent.Ef.ProductAgg.Services
{
    public class ProductDomainService : IProductDomainService
    {
        public bool IsExistSlug(string slug)
        {
            throw new NotImplementedException();
        }
    }
}
