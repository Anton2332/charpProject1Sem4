using BLL_Project2.DTO.Requests;
using BLL_Project2.DTO.Responses;
using BLL_Project2.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WEBAPI_Project2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OfferController:ControllerBase
    {
        private readonly IOffersService _offersService;

        public OfferController(IOffersService offersService) => _offersService = offersService;


        [HttpGet("get")]
        //[Authorize]
        public IActionResult get()
        {
            return Ok("Hi Tom");
        }

        [HttpPost("AddOffer")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> AddOfferAsync([FromBody] OfferRequestDTO offer)
        {

            try
            {
                await _offersService.AddAsync(offer);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpPut("UpdateOffer")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> UpdateOfferAsync([FromBody] OfferRequestDTO offer)
        {

            try
            {
                await _offersService.UpdateAsync(offer);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpDelete("DeleteOffer")]
        [Authorize]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult> DeleteOfferAsync([FromBody] int offerId)
        {

            try
            {
                await _offersService.DeleteAsync(offerId);

                return Ok();
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }

        [HttpGet("GetAllByOrderIdAndOrderByOffeeredPriceDescOffer")]
        [Authorize]
        //[ProducesResponseType(StatusCodes.Status200OK)]
        //[ProducesResponseType(StatusCodes.Status400BadRequest)]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<IEnumerable<OfferResponseDTO>>> GetAllByOrderIdAndOrderByOffeeredPriceDescOfferAsync(int orderId,int pageNumber)
        {

            try
            {
                var result = await _offersService.GetAllByOrderIdAndOrderByOffeeredPriceDesc(orderId,pageNumber);

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { e.Message });
            }
        }


    }
}
