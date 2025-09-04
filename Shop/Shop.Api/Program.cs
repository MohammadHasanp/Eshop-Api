using Common.AspNetCore;
using Common.AspNetCore.Middlewares;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Models;
using shop.Config;
using Shop.Api.Infrastructure;
using Shop.Api.Infrastructure.JwtUtil;

var builder = WebApplication.CreateBuilder(args);
var service = builder.Services;
// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
ProjectBootstrapper.RegisterShopDependency(service, connectionString);
DependencyRegister.RegisterApiDependency(service);


service.AddControllers()
    .ConfigureApiBehaviorOptions(option =>
    {
        option.InvalidModelStateResponseFactory = (context =>
        {
            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new()
                {
                    AppStatusCode = AppStatusCode.BadRequest,
                    Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
                }
            };
            return new BadRequestObjectResult(result);
        });
    });
service.AddJwtAuthentication(builder.Configuration);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
service.AddEndpointsApiExplorer();

var app = builder.Build();
// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("v1/swagger.json", "Shop API V1");
});

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.UseApiCustomExceptionHandler();
app.MapControllers();
app.Run();