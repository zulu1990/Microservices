﻿using AutoMapper;
using Ordering.Application.Featurs.Orders.Commands.CheckoutOrder;
using Ordering.Application.Featurs.Orders.Commands.UpdateOrder;
using Ordering.Application.Featurs.Orders.Queries.GerOrdersList;
using Ordering.Domain.Entities;

namespace Ordering.Application.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<Order, OrdersVm>().ReverseMap();
        CreateMap<Order, CheckoutOrderCommand>().ReverseMap();
        CreateMap<Order, UpdateOrderCommand>().ReverseMap();
    }
}
