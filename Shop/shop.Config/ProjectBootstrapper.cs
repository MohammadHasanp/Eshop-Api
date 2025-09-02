using Microsoft.Extensions.DependencyInjection;
using Shop.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Application._Utilities;
using Shop.Query.CategoryAgg.DTOs;
using Shop.Domain.CategoryAgg.Services;
using Shop.Domain.ProductAgg.DomainServices;
using Shop.Domain.SellerAgg.Services;
using Shop.Domain.UserAgg.Services;
using Shop.Infrastructure.Persistent.Ef.CategoryAgg.Services;
using Shop.Infrastructure.Persistent.Ef.ProductAgg.Services;
using Shop.Infrastructure.Persistent.Ef.SellerAgg.Services;
using Shop.Infrastructure.Persistent.Ef.UserAgg.Services;
using Common.Application.FileUtil.Interfaces;
using Common.Application.FileUtil.Services;
using Shop.Presentation.Facade;

namespace shop.Config
{
    public class ProjectBootstrapper
    {
        public static void RegisterShopDependency(IServiceCollection services,string connectionString)
        {
            InfrastructureBootstrapper.Init(services,connectionString);

            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<Directories>();
            });
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblyContaining<CategoryDto>();
            });

            services.AddTransient<ICategoryDomainServices,CategoryDomainService>();
            services.AddTransient<IProductDomainService,ProductDomainService>();
            services.AddTransient<ISellerDomainService,SellerDomainService>();
            services.AddTransient<IUserDomainService,UserDomainService>();
            services.AddTransient<IFileService,FileService>();
            FacadeBootstrapper.InitFacadeDependency(services);

        }
    }
}
