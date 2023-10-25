using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Dtos;

public class CreateOrderDto
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public int Quantity { get; set; }
    public double Price { get; set; }
    public string Status { get; set; }
    public CreateProductDto Product { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? CreatedAt { get; set; }
}
