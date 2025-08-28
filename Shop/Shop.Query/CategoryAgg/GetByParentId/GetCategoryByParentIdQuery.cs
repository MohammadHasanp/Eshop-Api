using Common.Query;
using Shop.Query.CategoryAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.CategoryAgg.GetByParentId
{
    public record GetCategoryByParentIdQuery(int ParentId):IQuery<List<SubCategoryDto>>;
}
