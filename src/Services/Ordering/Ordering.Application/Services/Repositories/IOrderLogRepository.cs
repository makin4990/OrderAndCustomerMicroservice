using CoreFramework.Persistence.Repositories;
using Ordering.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Services.Repositories;

public interface IOrderLogRepository: IAsyncRepository<OrderLog>,IRepository<OrderLog>
{

}
