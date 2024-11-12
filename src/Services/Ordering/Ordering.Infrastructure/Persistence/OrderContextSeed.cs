using Microsoft.Extensions.Logging;
using Ordering.Domain.Entities;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContextSeed
    {
        public static async Task SeedAsync(OrderContext orderContext, ILogger<OrderContextSeed> logger)
        {
            if (!orderContext.Orders.Any())
            {
                orderContext.Orders.AddRange(GetPreconfiguredOrders());
                await orderContext.SaveChangesAsync();
                logger.LogInformation("Seed database associated with context {DbContextName}", typeof(OrderContext).Name);
            }
        }

        private static IEnumerable<Order> GetPreconfiguredOrders()
        {
            return new List<Order>
            {
                new Order() 
                {
                    UserName = "swn", 
                    FirstName = "Mehmet",
                    LastName = "Ozkaya", 
                    EmailAddress = "ezozkme@gmail.com", 
                    AddressLine = "Bahcelievler",
                    Country = "Turkey",
                    TotalPrice = 350, 
                    CVV = "1111",
                    CardName = "12345678", 
                    CardNumber = "1231455134151231",
                    CreatedBy = "asd",
                    CreatedDate = DateTime.Now,
                    Expiration  ="2/27",
                    PaymentMethod = 1,
                    State = "asd",
                    ZipCode = "5415",LastModifiedBy = "ME", LastModifiedDate = DateTime.Now,
                }
            };
        }
    }
}

