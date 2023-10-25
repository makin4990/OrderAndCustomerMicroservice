using CoreFramework.Persistence.Repositories;
using Ordering.Application.Services.Repositories;
using Ordering.Domain.Entities;
using Ordering.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Persistence.Repositories;

public class OrderLogRepository : EfRepositoryBase<OrderLog, TesodevDbContext>, IOrderLogRepository
{
    public OrderLogRepository(TesodevDbContext context) : base(context)
    {
        
    }
}
