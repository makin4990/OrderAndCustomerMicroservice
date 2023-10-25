using CoreFramework.Persistence.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Dtos;

public class OrderListModelDto: BasePageableModel
{
    public IList<OrderDto> Items { get; set; }
}
