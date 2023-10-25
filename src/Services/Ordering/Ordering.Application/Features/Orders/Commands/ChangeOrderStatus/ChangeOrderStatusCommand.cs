using AutoMapper;
using CoreFramework.Application.Responses;
using MassTransit;
using MediatR;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Ordering.Application.Services.Repositories;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Response = CoreFramework.Application.Responses.Response;

namespace Ordering.Application.Features.Orders.Commands.ChangeOrderStatus;

public class ChangeOrderStatusCommand : IRequest<Response>
{
    public Guid Id { get; set; }
    public string Status { get; set; }
}

public class ChangeOrderStatusCommandHandler : IRequestHandler<ChangeOrderStatusCommand, Response>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public ChangeOrderStatusCommandHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<Response> Handle(ChangeOrderStatusCommand request, CancellationToken cancellationToken)
    {
        try
        {
            Order? existingOrder = await _orderRepository.GetAsync(i => i.Id == request.Id);
            if (existingOrder is null)
                return new ErrorResponse("Unable to update status");
            existingOrder.SetStatus(request.Status);
            await _orderRepository.UpdateAsync(existingOrder);

            return new SuccessResponse("Status is updated");

        }
        catch (Exception)
        {
            return new ErrorResponse("Unable to update status");

        }
    }
}
