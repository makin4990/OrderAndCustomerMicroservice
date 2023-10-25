using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Ordering.Application.Features.OrderLogs.Dtos;
using Ordering.Application.Services.Repositories;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ordering.Application.Services.OrderLogService;

public class OrderLogService : IOrderLogService
{
    private readonly IOrderLogRepository _orderLogRepository;
    private readonly IMapper _mapper;

    public OrderLogService(IOrderLogRepository orderLogRepository, IMapper mapper)
    {
        _orderLogRepository = orderLogRepository;
        _mapper = mapper;
    }

    public async Task<string> GetOrderLogs()
    {
        var begingdDate = DateTime.UtcNow.Date.AddDays(-2);
        var endDate = DateTime.UtcNow.Date;
        var logs = await _orderLogRepository.Query().Where(i => i.CreatedAt > begingdDate && i.CreatedAt < endDate).ToListAsync();

        string jsonResult = JsonSerializer.Serialize(logs);
        return jsonResult;
    }

    public async Task CreateAsync(OrderLogDto orderLogDto)
    {
        try
        {
            var orderLog = _mapper.Map<OrderLog>(orderLogDto);
            await _orderLogRepository.AddAsync(orderLog);

        }
        catch (Exception ex)
        {

            throw ex;
        }
    }
}
