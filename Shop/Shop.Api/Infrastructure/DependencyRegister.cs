using Shop.Api.Infrastructure.JwtUtil;
using Shop.Api.Infrastructure.Security;

namespace Shop.Api.Infrastructure
{
    public static class DependencyRegister
    {
        public static void RegisterApiDependency(IServiceCollection services)
        {
            services.AddTransient<CustomJwtValidation>();
            services.AddAutoMapper(cfg =>
            {
                cfg.AddProfile<MapperProfile>();
            });
            services.AddCors(options =>
            {
                options.AddPolicy(name: "ShopApi",
                    builder =>
                    {
                        builder.AllowAnyOrigin()
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });
        }
    }
}
