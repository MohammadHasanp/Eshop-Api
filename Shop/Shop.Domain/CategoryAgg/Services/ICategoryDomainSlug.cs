using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.CategoryAgg.Services
{
    public interface ICategoryDomainSlug
    {
        bool IsExistSlug(string slug);
    }
}
