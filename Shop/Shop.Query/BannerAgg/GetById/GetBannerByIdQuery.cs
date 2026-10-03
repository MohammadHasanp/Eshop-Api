using Common.Query;
using Shop.Query.BannerAgg.DTOs;

namespace Shop.Query.BannerAgg.GetById
{
    public record GetBannerByIdQuery(long BannerId) : IQuery<BannerDto>;

}
