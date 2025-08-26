using Common.Query;
using Shop.Query.CategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.CategoryAgg.GetById
{
    public record GetCategoryByIdQuery(long categoryId):IQuery<CategoryDto>;
}
