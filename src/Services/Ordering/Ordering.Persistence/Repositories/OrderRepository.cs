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

public class OrderRepository:EfRepositoryBase<Order,TesodevDbContext>,IOrderRepository
{
    public OrderRepository(TesodevDbContext context) :base(context)
    {
            
    }
}
