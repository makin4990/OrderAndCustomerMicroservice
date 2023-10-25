using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.WebApi.Models.ResponseModels;

public interface IDataResponse<T> : IResponse
{
    T Data { get; }
}
