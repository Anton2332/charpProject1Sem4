using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using project1.Model;
using project1.Repositories.Interface;
using WEBAPI.BLL.DTO.Requests;
using WEBAPI.BLL.DTO.Responses;
using WEBAPI.BLL.Interfaces;

namespace WEBAPI.Controllers
{
    public class RepliesController:ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private IRepliesService _repliesService;

        public RepliesController(ILogger<PostController> logger, IRepliesService repliesService)
        {
            _logger = logger;
            _repliesService = repliesService;
        }

        //GET
        [HttpGet("GetAllRepliesByPostId")]
        public async Task<ActionResult<IEnumerable<RepliesResponsDTO>>> GetAllById(long Id)
        {
            try
            {
                var results = await _repliesService.GetAllByPostIdAsync(Id);
                //_unitOfWOrk.Commit();
                _logger.LogInformation($"Returned replies of post by post id {Id} from database");
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! \n Something went wrong insede GetAllByPostIdAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal serve error");
            }
        }

        //[HttpGet("GetPostById")]
        //public async Task<ActionResult<replies>> GetById(long Id)
        //{
        //    try
        //    {
        //        var result = await _unitOfWOrk.RepliesRepository.GetAsync(Id);
        //        _unitOfWOrk.Commit();
        //        _logger.LogInformation($"Returned replies of id {Id} from database");
        //        return Ok(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError($"Transaction Failed! \nSomething want wrong insede GetAsync action: {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        //    }
        //}

        //POST
        [HttpPost("Post")]
        public async Task<ActionResult<long>> Post([FromBody] RepliesRequestDTO post)
        {

            try
            {
                if (post == null)
                {
                    _logger.LogError("Comment object sent from client is null.");
                    return BadRequest("Comment object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Comment object sent from client.");
                    return BadRequest("Invalid model object");
                }
                var result = await _repliesService.AddAsync(post);
                //_unitOfWOrk.Commit();
                _logger.LogInformation($"Add post by id {post.Id}");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! \nSomething want wrong insede AddAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        //PUT
        [HttpPut("PostUpdate")]
        public async Task<ActionResult> Put([FromBody] RepliesRequestDTO post)
        {
            try
            {
                if (post == null)
                {
                    _logger.LogError("Comment object sent from client is null.");
                    return BadRequest("Comment object is null");
                }
                if (!ModelState.IsValid)
                {
                    _logger.LogError("Invalid Comment object sent from client.");
                    return BadRequest("Invalid model object");
                }
                await _repliesService.UpdateAsync(post);
                //_unitOfWOrk.Commit();
                _logger.LogInformation($"Updete post by id {post.Id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! \nSomething want wrong insede ReplaceAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        //DELETE
        [HttpDelete("Post/{Id}")]
        public async Task<ActionResult> Delete([FromBody] long id)
        {
            try
            {
                await _repliesService.DeleteAsync(id);
                //_unitOfWOrk.Commit();
                _logger.LogInformation($"Delete post by id {id}");
                return Ok();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! \nSomething want wrong insede DeleteAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }
    }
}
