using CoreFramework.Application.Responses;
using Ordering.Infrastructure.Consts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Ordering.Infrastructure.Services.ValidateCustomer;

public class CustomerValidationService : ICustomerValidationService
{
    private readonly HttpClient _httpClient;


    public CustomerValidationService(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient("CustomerApi");
    }
    public async Task<Response> ValidateCustomerById(Guid id)
    {
        var response = await _httpClient.GetAsync(CustomEndPoints.ValidateCustomerAsync+$"?id={id}");
        if (response.IsSuccessStatusCode)
        {
            return new SuccessResponse();
        }
        else
        {
            return new ErrorResponse();
        }

    }
}
