using Discount.Api.Application.Repositories;
using Discount.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class DiscountController : ControllerBase
    {
        private readonly IDiscountRepository _repository;
        private readonly ILogger<DiscountController> _logger;

        public DiscountController(ILogger<DiscountController> logger, IDiscountRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        [HttpGet("{productName}", Name = "GetDiscount")]
        public async Task<ActionResult<Coupon>> GetDiscount(string productName)
        {
            var coupon = await _repository.GetDiscount(productName);
            return Ok(coupon);
        }
        

    }
}
