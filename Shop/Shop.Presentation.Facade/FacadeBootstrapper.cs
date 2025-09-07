using Microsoft.Extensions.DependencyInjection;
using Shop.Presentation.Facade.BannerAgg;
using Shop.Presentation.Facade.CategoryAgg;
using Shop.Presentation.Facade.CommentAgg;
using Shop.Presentation.Facade.OrderAgg;
using Shop.Presentation.Facade.ProductAgg;
using Shop.Presentation.Facade.RoleAgg;
using Shop.Presentation.Facade.SellerAgg;
using Shop.Presentation.Facade.SellerAgg.Inventory;
using Shop.Presentation.Facade.SliderAgg;
using Shop.Presentation.Facade.UserAgg;
using Shop.Presentation.Facade.UserAgg.UserAddress;

namespace Shop.Presentation.Facade
{
    public static class FacadeBootstrapper
    {
        public static void InitFacadeDependency(this IServiceCollection services)
        {
            services.AddScoped<IBannerFacade, BannerFacade>();
            services.AddScoped<ICategoryFacade, CategoryFacade>();
            services.AddScoped<ICommentFacade, CommentFacede>();
            services.AddScoped<IOrderItemFacade, OrderFacade>();
            services.AddScoped<IProductFacade, ProductFacade>();
            services.AddScoped<ISellerFacade, SellerFacade>();
            services.AddScoped<IRoleFacade, roleFacade>();
            services.AddScoped<ISliderFacade, SliderFacade>();
            services.AddScoped<IUserFacade, UserFacade>();
            services.AddScoped<ISellerInventoryFacade, SellerInventoryFacade>();
            services.AddScoped<IUserAddressFacade, UserAddressFacade>();
        }
    }
}
