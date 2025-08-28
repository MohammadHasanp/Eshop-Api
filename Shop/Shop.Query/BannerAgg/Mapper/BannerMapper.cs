using Shop.Domain.SiteEntities;
using Shop.Query.BannerAgg.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Query.BannerAgg.Mapper
{
    public static class BannerMapper
    {
        public static BannerDto Map(this Banner banner)
        {
            return new BannerDto()
            {
                CreationDate = banner.CreationDate,
                Id = banner.Id,
                ImageName = banner.ImageName,
                Link = banner.Link,
                Position = banner.Position
            };
        }

        public static List<BannerDto> MapList(this List<Banner> banner)
        {
            var banners = new List<BannerDto>();
            banner.ForEach(b =>
            {
                banners.Add(new BannerDto
                {
                    CreationDate = b.CreationDate,
                    Id = b.Id,
                    ImageName = b.ImageName,
                    Link = b.Link,
                    Position = b.Position
                });
            });
            return banners;
        }
    }
}
