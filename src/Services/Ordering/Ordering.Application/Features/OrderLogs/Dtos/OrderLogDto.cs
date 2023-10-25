using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.OrderLogs.Dtos;

public class OrderLogDto
{
    public Guid OrderId { get; set; }
    public string LogAsJson { get; set; }
}
