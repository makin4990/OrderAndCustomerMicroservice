using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.MassTransitShared.OrderContract;

public class CreateOrderMessage
{
    public Guid OrderId { get; set; }
    public string LogAsJson { get; set; }
}
