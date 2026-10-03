using Common.Query;
using Microsoft.EntityFrameworkCore.Metadata.Conventions.Infrastructure;
using Shop.Domain.SiteEntities;
using Shop.Query.BannerAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.BannerAgg.GetList
{
    public record GetAllBannerQuery() : IQuery<List<BannerDto>>;
}
