﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Customers.WebApi.Models.ResponseModels;

public class SuccessResponse:Response
{
    public SuccessResponse(string message) : base(true, message)
    {

    }

    public SuccessResponse() : base(true)
    {

    }
}
