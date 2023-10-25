using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.WebApi.Models.ResponseModels;

public interface IResponse
{
    bool Success { get; }
    string Message { get; }
}
