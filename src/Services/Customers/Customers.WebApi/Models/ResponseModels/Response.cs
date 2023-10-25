using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customers.WebApi.Models.ResponseModels;

public class Response: IResponse
{
    public Response()
    {
        
    }
    public Response(bool success, string message) : this(success)
    {
        Message = message;
    }

    public Response(bool success)
    {
        Success = success;
    }

    public bool Success { get; set; }

    public string Message { get; set; }
}
