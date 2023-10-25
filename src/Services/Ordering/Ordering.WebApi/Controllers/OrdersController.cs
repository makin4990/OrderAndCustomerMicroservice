using CoreFramework.Application.Responses;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.ChangeOrderStatus;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Dtos;
using Ordering.Application.Features.Orders.Queries.GetAllOrders;
using Ordering.Application.Features.Orders.Queries.GetOrderById;
using Ordering.Application.Features.Orders.Queries.GetOrderListByCustomerId;

namespace Ordering.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetOrdersAsync")]
        public async Task<IActionResult> GetListAsync()
        {
            GetAllOrdersQuery getListQuery = new();
            DataResponse<IEnumerable<OrderDto>> result = await _mediator.Send(getListQuery);
            return result.Success ? Ok(result) : BadRequest(result);

        }

        [HttpGet("GetOrdersByCustomerIdAsync")]
        public async Task<IActionResult> GetOrdersByCustomerIdAsync(Guid Id)

        {
            GetOrderListByCustomerIdQuery getListQuery = new() { CustomerId = Id};
            DataResponse<IEnumerable<OrderDto>> result = await _mediator.Send(getListQuery);
            return result.Success ? Ok(result) : BadRequest(result);

        }

        [HttpGet("GetOrdersByIdAsync")]
        public async Task<IActionResult> GetOrdersByIdAsync(Guid Id)

        {
            GetOrderByIdQuery getOrder = new() { Id = Id };
            DataResponse<OrderDto> result = await _mediator.Send(getOrder);
            return result.Success ? Ok(result) : BadRequest(result);

        }

        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateOrderCommand command)
        {
            DataResponse<Guid> result = await _mediator.Send(command);
            return result.Success? Created("",result):BadRequest(result);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync([FromBody] UpdateOrderCommand command)
        {
            Response result = await _mediator.Send(command);
            return result.Success ? Ok(result):BadRequest(result);
        }
        [HttpPatch("SetStatusAsync")]
        public async Task<IActionResult> SetStatusAsync([FromBody] ChangeOrderStatusCommand command)
        {
            Response result = await _mediator.Send(command);
            return result.Success ? Ok(result) : BadRequest(result);
        }
        [HttpDelete("DeleteAsync")]
        public async Task<IActionResult> DeleteAsync([FromQuery] Guid Id)
        {
            DeleteOrderCommand command = new() { Id = Id };
            Response result = await _mediator.Send(command);
            return result.Success?  Ok(result) : BadRequest(result);
        }
    }
}
