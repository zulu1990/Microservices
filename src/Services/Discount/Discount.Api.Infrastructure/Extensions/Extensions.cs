using Discount.Api.Application.Repositories;
using Discount.Api.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Discount.Api.Infrastructure.Extensions
{
    public static class Extensions
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IDiscountRepository, DiscountRepository>();
        }
    }
}
