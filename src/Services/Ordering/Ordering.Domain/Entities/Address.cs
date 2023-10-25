using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities;

public record Address
{
    public string AddressLine { get; set; }
    public string City { get; set; }
    public string Country { get; set; }
    public int CityCode { get; set; }

}
