using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Features.Orders.Dtos;

public class CreateProductDto
{
    public Guid Id = Guid.NewGuid();
    public string Name { get; set; }
    public string ImageUrl { get; set; }
}
