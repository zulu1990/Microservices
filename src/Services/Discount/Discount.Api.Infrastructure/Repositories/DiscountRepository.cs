using Discount.Api.Application.Repositories;
using Discount.Api.Entities;
using Microsoft.Extensions.Configuration;
using Npgsql;
using Dapper;

namespace Discount.Api.Infrastructure.Repositories;

public class DiscountRepository : IDiscountRepository
{
    private readonly string _connectionString;

    public DiscountRepository(IConfiguration config)
    {
        _connectionString = config.GetConnectionString("NpgSql") ?? throw new ArgumentNullException(nameof(config));
    }


    public async Task<bool> CreateDiscount(Coupon coupon)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var affected =
            await connection.ExecuteAsync
                ("INSERT INTO Coupon (ProductName, Description, Amount) VALUES (@ProductName, @Description, @Amount)",
                        new { ProductName = coupon.ProductName, Description = coupon.Description, Amount = coupon.Amount });

        if (affected == 0)
            return false;

        return true;
    }

    public Task<bool> DeleteDiscount(string productName)
    {
        throw new NotImplementedException();
    }

    public async Task<Coupon> GetDiscount(string productName)
    {
        using var connection = new NpgsqlConnection(_connectionString);

        var coupon = await connection.QueryFirstOrDefaultAsync<Coupon>
            ("SELECT * FROM Coupon WHERE ProductName = @ProductName", new { ProductName = productName });

        if (coupon == null)
            return new Coupon
            { 
                ProductName = "No Discount",
                Amount = 0, 
                Description = "No Discount Desc" 
            };

        return coupon;
    }

    public Task<bool> UpdateDiscount(Coupon coupon)
    {
        throw new NotImplementedException();
    }
}
