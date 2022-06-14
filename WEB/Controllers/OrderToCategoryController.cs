using Application.OrderToCatogory.Commands.CreateOrderToCategory;
using Application.OrderToCatogory.Queries.GetOrderToCategoryByOrderIdList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderToCategoryController:ControllerBase
    {
        private ISender _mediator;

        public OrderToCategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetAllByCategoryId")]
        public async Task<ActionResult<IEnumerable<OrderToCategoryDTO>>> GetAll([FromQuery] GetOrderToCategoryByOrderIdListQuery query)
        {
            var result = await _mediator.Send(query);
            if(result != null)
            {
                return Ok(result);
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateOrderToCategoryCommand command)
        {
            return await _mediator.Send(command);
        }
    }
}
