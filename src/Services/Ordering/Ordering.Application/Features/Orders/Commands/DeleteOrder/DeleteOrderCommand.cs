using AutoMapper;
using CoreFramework.Application.Responses;
using MediatR;
using Ordering.Application.Services.Repositories;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Commands.DeleteOrder;

public class DeleteOrderCommand:IRequest<Response>
{
    public Guid Id { get; set; }
}
public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Response>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public DeleteOrderCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
    {
		try
		{
            Order? existingOrder = await _orderRepository.GetAsync(i=> i.Id == request.Id);
            if (existingOrder is null)
                return new ErrorResponse("Unable to delete order");
            await _orderRepository.DeleteAsync(existingOrder);

            return new SuccessResponse();
        }
        catch (Exception)
		{
            return new ErrorResponse("Unable to delete order");
		}
    }
}
