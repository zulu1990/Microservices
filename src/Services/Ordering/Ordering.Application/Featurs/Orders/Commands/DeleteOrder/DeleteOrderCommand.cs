using MediatR;

namespace Ordering.Application.Featurs.Orders.Commands.DeleteOrder;

public record DeleteOrderCommand(int Id) : IRequest;

