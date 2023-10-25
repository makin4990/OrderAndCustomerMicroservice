using AutoMapper;
using CoreFramework.Application.Responses;
using MassTransit;
using MediatR;
using Ordering.Application.Features.Orders.Dtos;
using Ordering.Application.Services.Repositories;
using Ordering.Domain.Entities;
using Ordering.Infrastructure.Services.ValidateCustomer;
using Ordering.MassTransitShared.OrderContract;
using System.Text.Json;

namespace Ordering.Application.Features.Orders.Commands.CreateOrder;

public class CreateOrderCommand : IRequest<DataResponse<Guid>>
{
    public Guid CustomerId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    public CreateProductDto Product { get; set; }
    public Address Address { get; set; }

}

public class CreateOrderCommnadHandler : IRequestHandler<CreateOrderCommand, DataResponse<Guid>>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IMapper _mapper;
    private readonly ICustomerValidationService _customerValidationService;
    private readonly IPublishEndpoint _publishEndpoint;

    public CreateOrderCommnadHandler(IOrderRepository orderRepository, IMapper mapper, ICustomerValidationService customerValidationService, IPublishEndpoint publishEndpoint)
    {
        _orderRepository = orderRepository;
        _mapper = mapper;
        _customerValidationService = customerValidationService;
        _publishEndpoint = publishEndpoint;
    }

    public async Task<DataResponse<Guid>> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var checkIfCustomerExist = await _customerValidationService.ValidateCustomerById(request.CustomerId);
            if (!checkIfCustomerExist.Success)
                return new ErrorDataResponse<Guid>("Validation error occured");

            Order order = _mapper.Map<Order>(request);
            var createdOrder = await _orderRepository.AddAsync(order);
            var response = new DataResponse<Guid>(createdOrder.Id, true, "Order created.");

            
            await PublishCreatedOrder(createdOrder);

            return response;

        }
        catch (Exception ex)
        {

           return new ErrorDataResponse<Guid>(Guid.Empty,ex.Message);
        }
    }

    private async Task PublishCreatedOrder(Order createdOrder)
    {
        OrderDto dto = _mapper.Map<OrderDto>(createdOrder);
        string json = JsonSerializer.Serialize(dto);
        await _publishEndpoint.Publish(new CreateOrderMessage { OrderId = dto.Id, LogAsJson = json });
    }
}
