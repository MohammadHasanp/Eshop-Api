using Shop.Api.Infrastructure.JwtUtil;

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
        }
    }
}
