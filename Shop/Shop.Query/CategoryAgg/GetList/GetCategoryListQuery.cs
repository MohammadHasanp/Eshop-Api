using Common.Query;
using Shop.Domain.CategoryAgg;
using Shop.Query.CategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.CategoryAgg.GetList
{
    public record GetCategoryListQuery : IQuery<List<CategoryDto>>;
}
