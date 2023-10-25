using AutoMapper;
using CoreFramework.Application.Responses;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Features.Orders.Dtos;
using Ordering.Application.Services.Repositories;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Queries.GetOrderById;

public class GetOrderByIdQuery:IRequest<DataResponse<OrderDto>>
{
    public Guid Id { get; set; }
}
public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, DataResponse<OrderDto>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderByIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<DataResponse<OrderDto>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
    {
        Order? order = await _orderRepository.Query().Where(i=> i.Id == request.Id).Include(i=> i.Product).FirstOrDefaultAsync();
        if (order is null)
            return new ErrorDataResponse<OrderDto>("Order not found");
        OrderDto result = _mapper.Map<OrderDto>(order);
        return new SuccessDataResponse<OrderDto>(result);
    }
}
