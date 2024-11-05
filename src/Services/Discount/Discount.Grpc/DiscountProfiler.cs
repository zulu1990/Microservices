
using AutoMapper;
using Discount.Grpc.Protos;

namespace Discount.Grpc
{
    public class DiscountProfiler : Profile
    {
        public DiscountProfiler()
        {
            CreateMap<Coupon, CouponModel>().ReverseMap();
        }
    }
}
