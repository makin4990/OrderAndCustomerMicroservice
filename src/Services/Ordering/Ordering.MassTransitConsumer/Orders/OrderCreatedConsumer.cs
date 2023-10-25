using MassTransit;
using Ordering.Application.Features.OrderLogs.Dtos;
using Ordering.Application.Services.OrderLogService;
using Ordering.MassTransitShared.OrderContract;

namespace Ordering.MassTransitConsumer.Orders;

public class OrderCreatedConsumer : IConsumer<CreateOrderMessage>
{
    private readonly IOrderLogService _orderLogService;

    public OrderCreatedConsumer(IOrderLogService orderLogService)
    {
        _orderLogService = orderLogService;
    }

    public async Task Consume(ConsumeContext<CreateOrderMessage> context)
    {

        await Console.Out.WriteLineAsync($"{context.Message.OrderId}");
        await _orderLogService.CreateAsync(new OrderLogDto { OrderId = context.Message.OrderId, LogAsJson = context.Message.LogAsJson });
    }
}
