using CoreApiResponse;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Features.Orders.Commands.CreateOrder;
using Ordering.Application.Features.Orders.Commands.DeleteOrder;
using Ordering.Application.Features.Orders.Commands.UpdateOrder;
using Ordering.Application.Features.Orders.Queries.GetOrderByUserName;
using System.Net;

namespace Ordering.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class OrderController : BaseController
    {
        IMediator _mediator;
        public OrderController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<OrderVm>), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetOrderByUserName(string userName)
        {
            try
            {
                var orders=_mediator.Send(new GetUserByOrderQueries(userName));
                return CustomResult("Order load sucessfully",orders);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand orderCommand)
        {
            try
            {
                var isOrderPlaced = await _mediator.Send(orderCommand);
                if (isOrderPlaced)
                {
                    return CustomResult("Order Placed sucessfully");
                }
                return CustomResult("Result is not placed", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpPut]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateOrder(UpdateOrderCommand orderCommand)
        {
            try
            {
                var isModifiedOrder = await _mediator.Send(orderCommand);
                if (isModifiedOrder)
                {
                    return CustomResult("Order Placed modified sucessfully");
                }
                return CustomResult("Result is not placed", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }
        [HttpDelete]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteOrder(int orderId)
        {
            try
            {
                var isDeleteOrder = await _mediator.Send(new DeleteOrderCommand() { Id=orderId});
                if (isDeleteOrder)
                {
                    return CustomResult("Order Deleted sucessfully");
                }
                return CustomResult("Delete order failed", HttpStatusCode.BadRequest);
            }
            catch (Exception ex)
            {
                return CustomResult(ex.Message, HttpStatusCode.BadRequest);
            }
        }

    }
}
