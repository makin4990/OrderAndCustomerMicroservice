using Ordering.Application.Features.Orders.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Models;

public class OrderListModel
{
    public IList<OrderDto> Orders { get; set; }
}
