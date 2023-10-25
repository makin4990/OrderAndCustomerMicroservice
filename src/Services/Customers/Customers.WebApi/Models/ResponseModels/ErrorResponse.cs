using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.WebApi.Models.ResponseModels;

public class ErrorResponse:Response
{
    public ErrorResponse(string message) : base(true, message)
    {

    }

    public ErrorResponse() : base(true)
    {

    }
}
