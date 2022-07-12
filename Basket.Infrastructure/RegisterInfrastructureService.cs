using Basket.Domain.Contracts;
using Basket.Infrastructure.Context;
using Basket.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Basket.Infrastructure
{
    public static class RegisterInfrastructureService
    {
        public static IServiceCollection RegisterInfrastructureServices(this IServiceCollection services)
        {
            services.AddScoped<IApplicationContext, ApplicationContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            
            return services;
        }
    }
}