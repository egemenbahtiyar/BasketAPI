using Basket.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application
{
    public static class RegisterApplicationService
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductService>();
            service.AddScoped<IUserService, UserService>();
            service.AddScoped<IBasketService, BasketService>();
            
            return service;
        }
    }
}