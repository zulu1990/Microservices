using MediatR;

namespace Ordering.Application.Featurs.Orders.Queries.GerOrdersList;

public record GetOrdersListQuery(string UserName) : IRequest<List<OrdersVm>>;
