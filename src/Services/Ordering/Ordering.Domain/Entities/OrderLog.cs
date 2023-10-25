using CoreFramework.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Domain.Entities
{
    public class OrderLog:Entity
    {
        public Guid OrderId { get; set; }
        public string LogAsJson { get; set; }

    }
}
