using Common.Query;
using Shop.Query.BannerAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.BannerAgg.GetById
{
    public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>;

}
