using Basket.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Application
{
    public static class RegisterApplicationService
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection service)
        {
            service.AddScoped<IProductService, ProductService>();
            
            return service;
        }
    }
}