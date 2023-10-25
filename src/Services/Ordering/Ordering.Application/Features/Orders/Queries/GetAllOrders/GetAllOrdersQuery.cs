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

namespace Ordering.Application.Features.Orders.Queries.GetAllOrders;

public class GetAllOrdersQuery:IRequest<DataResponse<IEnumerable<OrderDto>>>
{
}
public class GetAllOrderQueryHandler : IRequestHandler<GetAllOrdersQuery, DataResponse<IEnumerable<OrderDto>>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetAllOrderQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<DataResponse<IEnumerable<OrderDto>>> Handle(GetAllOrdersQuery request, CancellationToken cancellationToken)
    {
		try
		{
            List<Order> orders = await _orderRepository.Query().Include(i=> i.Product).ToListAsync();

            if(!orders.Any())
                return new ErrorDataResponse<IEnumerable<OrderDto>>("Order not found");

            IEnumerable<OrderDto> result = _mapper.Map<IEnumerable<OrderDto>>(orders);
            return new SuccessDataResponse<IEnumerable<OrderDto>>(result);
		}
		catch (Exception)
		{
            return new ErrorDataResponse<IEnumerable<OrderDto>>("Order not found");
		}
    }
}
