using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.ProductAgg.DomainServices
{
    public interface IProductDomainService
    {
        //For Tto Exist Slug
        bool IsExistSlug(string slug);
    }
}
