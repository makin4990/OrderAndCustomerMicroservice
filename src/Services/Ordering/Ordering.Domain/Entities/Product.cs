using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities;

public class Product
{
    public Product(Guid id, string name, string imageUrl)
    {
        Id = id;
        Name = name;
        ImageUrl = imageUrl;
    }

    public Guid Id { get; private set; }
    public string Name { get; private set; }
    public string ImageUrl { get; private set; }
}
