using Customers.WebApi.Models;
using Customers.WebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Customers.WebApi.ControllersÜ;

[Route("api/[controller]")]
[ApiController]
public class CustomersController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomersController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("GetAllAsync")]
    public async Task<IActionResult> GetAllCustomersAsync()
    {
        var result = await _customerService.GetAllAsync();

        return result.Success? Ok(result):BadRequest(result);
    }

    [HttpGet("GetCustomerByIdAsync")]
    public async Task<IActionResult> GetCustomerByIdAsync([FromQuery] Guid id)
    {
        var result = await _customerService.GetByIdAsync(id);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPost("CreateAsync")]
    public async Task<IActionResult> CreateAsync([FromBody] Customer customer)
    {
        var result = await _customerService.CreateAsync(customer);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpPut("UpdateAsync")]
    public async Task<IActionResult> UpdateAsync([FromBody] Customer customer)
    {
        var result = await _customerService.UpdateAsync(customer.Id,customer);

        return result.Success ? Ok(result) : BadRequest(result);
    }


    [HttpDelete("DeleteAsync")]
    public async Task<IActionResult> DeleteAsync([FromQuery] Guid id)
    {
        var result = await _customerService.DeleteAsync(id);

        return result.Success ? Ok(result) : BadRequest(result);
    }

    [HttpGet("ValidateAsync")]
    public async Task<IActionResult> ValidateAsync([FromQuery] Guid id)
    {
        var result = await _customerService.ValidateAsync(id);

        return result.Success ? Ok(result) : BadRequest(result);
    }
}
