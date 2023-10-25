using Ordering.Application.Features.OrderLogs.Dtos;

namespace Ordering.Application.Services.OrderLogService;

public interface IOrderLogService
{
    Task<string> GetOrderLogs();
    Task CreateAsync(OrderLogDto orderLogDto);
}