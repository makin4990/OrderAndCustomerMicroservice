using AutoMapper;
using CoreFramework.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Features.Orders.Dtos;
using Ordering.Application.Services.Repositories;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Commands.UpdateOrder;

public class UpdateOrderCommand: IRequest<Response>
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    public UpdateProductDto Product { get; set; }
    public Address Address { get; set; }
}

public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand,Response>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public UpdateOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Order existingOrder = await _orderRepository.Query().Where(i => i.Id == request.Id).Include(i => i.Product).FirstAsync();
            if (existingOrder is null)
                return new ErrorResponse("Unable to update order");
        
            Order? order = _mapper.Map(request,existingOrder);
            order.Update();
            await _orderRepository.UpdateAsync(order);
            
            return new SuccessResponse("Order updated");

        }
        catch (Exception)
        {
            return new ErrorResponse("Unable to update order");
        }

    }
}
