using BLL_Project2.DTO.Requests;
using BLL_Project2.DTO.Responses;
using BLL_Project2.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI_Project2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController:ControllerBase
    {

        private readonly IOrdersService _ordersService;

        public OrderController(IOrdersService ordersService) => _ordersService = ordersService;


        [HttpPost("AddOrder")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddOfferAsync([FromBody] OrderRequestDTO order)
        {

            try
            {
                await _ordersService.AddAsync(order);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPut("UpdateOrder")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateOfferAsync([FromBody] OrderRequestDTO order)
        {

            try
            {
                await _ordersService.UpdateAsync(order);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpDelete("DeleteOffer")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteOfferAsync([FromBody] int orderId)
        {

            try
            {
                await _ordersService.DeleteAsync(orderId);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllByAllIdAndOrderByNameDescAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllByAllIdAndOrderByNameDescAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllByAllIdAndOrderByNameDescAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllByAllIdAndOrderByMaximumPriceDescAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllByAllIdAndOrderByMaximumPriceDescAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllByAllIdAndOrderByMaximumPriceDescAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllByAllIdAndOrderByMaximumDayDescAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllByAllIdAndOrderByMaximumDayDescAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllByAllIdAndOrderByMaximumDayDescAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }


        [HttpGet("GetAllByAllIdAndOrderByDateOrderDescAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllByAllIdAndOrderByDateOrderDescAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllByAllIdAndOrderByDateOrderDescAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllByAllIdAndOrderByNameAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllByAllIdAndOrderByNameAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllByAllIdAndOrderByNameAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllByAllIdAndOrderByMaximumPriceAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllByAllIdAndOrderByMaximumPriceAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllByAllIdAndOrderByMaximumPriceAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllByAllIdAndOrderByMaximumDayAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllByAllIdAndOrderByMaximumDayAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllByAllIdAndOrderByMaximumDayAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllByAllIdAndOrderByDateOrderAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllByAllIdAndOrderByDateOrderAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllByAllIdAndOrderByDateOrderAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllAndOrderByNameDescAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllAndOrderByNameDescAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllAndOrderByNameDescAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllAndOrderByMaximumPriceDescAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllAndOrderByMaximumPriceDescAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllAndOrderByMaximumPriceDescAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllAndOrderByMaximumDayDescAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllAndOrderByMaximumDayDescAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllAndOrderByMaximumDayDescAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllAndOrderByDateOrderDescAsync")]
        //[Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OrderResponseDTO>>> GetAllAndOrderByDateOrderDescAsync(List<int> orderId, int pageNumber)
        {

            try
            {
                var result = await _ordersService.GetAllAndOrderByDateOrderDescAsync(orderId, pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }


    }
}
