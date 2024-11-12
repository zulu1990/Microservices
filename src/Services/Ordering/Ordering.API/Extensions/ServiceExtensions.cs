using MediatR;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Ordering.Infrastructure.Persistence;

namespace Ordering.API.Extensions
{
    public static class ServiceExtensions
    {
        public static void MigrateDatabase(this IServiceProvider services, int? retry = 0)
        {
            int retryForAvailability = retry.Value;
            var score = services.CreateScope();
            var context = score.ServiceProvider.GetRequiredService<OrderContext>();
            var logger = score.ServiceProvider.GetRequiredService<ILogger<OrderContextSeed>>();
            

            try
            {
                logger.LogInformation("Migrating database associated with context {DbContextName}", typeof(OrderContext).Name);
                context.Database.Migrate();
                OrderContextSeed.SeedAsync(context, logger).Wait();


                logger.LogInformation("Migrated database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
            catch (SqlException ex)
            {
                logger.LogError(ex, "An error occurred while migrating the database used on context {DbContextName}", typeof(OrderContext).Name);

                if (retryForAvailability < 50)
                {
                    retryForAvailability++;
                    MigrateDatabase(services, retryForAvailability);
                }
            }

        }

    }
}
