using Common.Query;
using Shop.Query.ProductAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.ProductAgg.GetById
{
    public record GetProductByIdQuery(long ProductId) : IQuery<ProductDto>;
}
