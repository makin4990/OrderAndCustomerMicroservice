using AutoMapper;
using CoreFramework.Application.Responses;
using CoreFramework.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Features.Orders.Dtos;
using Ordering.Application.Services.Repositories;
using Ordering.Domain.Entities;

namespace Ordering.Application.Features.Orders.Queries.GetOrderListByCustomerId;

public class GetOrderListByCustomerIdQuery:IRequest<DataResponse<IEnumerable<OrderDto>>>
{
    public Guid CustomerId { get; set; }
}
public class GetOrderListByCustomerIdQueryHandler : IRequestHandler<GetOrderListByCustomerIdQuery, DataResponse<IEnumerable<OrderDto>>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;

    public GetOrderListByCustomerIdQueryHandler(IOrderRepository orderRepository, IMapper mapper)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
    }

    public async Task<DataResponse<IEnumerable<OrderDto>>> Handle(GetOrderListByCustomerIdQuery request, CancellationToken cancellationToken)
    {
		try
		{
            List<Order> orders = await _orderRepository.Query().Where(i=> i.CustomerId== request.CustomerId)
                                                               .Include(i=> i.Address)
                                                               .Include(i=> i.Product)
                                                               .ToListAsync();
            if (!orders.Any())
                return new ErrorDataResponse<IEnumerable<OrderDto>>("Orders not found");
            IEnumerable<OrderDto> result = _mapper.Map<List<Order>, IEnumerable<OrderDto>>(orders);
         
            return new SuccessDataResponse<IEnumerable<OrderDto>>(result);

		}
		catch (Exception)
		{

            return new ErrorDataResponse<IEnumerable<OrderDto>>("Orders not found");
        }
    }
}
