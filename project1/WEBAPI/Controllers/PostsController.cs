using DAL.Model;
using Microsoft.AspNetCore.Mvc;
using project1.Model;
using project1.Repositories.Interface;
using WEBAPI.BLL.DTO.Requests;
using WEBAPI.BLL.DTO.Responses;
using WEBAPI.BLL.Interfaces;

namespace WEBAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostController:ControllerBase
    {
        private readonly ILogger<PostController> _logger;
        private IPostService _postService;

        public PostController(ILogger<PostController> logger,IPostService postService)
        {
            _logger = logger;
            _postService = postService;
        }

        //GET
        [HttpGet("GetAllPostsByOrderId")]
        public async Task<ActionResult<IEnumerable<PostResponsDTO>>> GetAllById(long Id)
        {
            try
            {
                var results = await _postService.GetAllByOrderIdAsync(Id);
                //_unitOfWOrk.Commit();
                _logger.LogInformation($"Returned posts of order by order id {Id} from database");
                return Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError($"Transaction Failed! \n Something went wrong insede GetAllPostsByOrderIdAsync action: {ex.Message}");
                return StatusCode(StatusCodes.Status500InternalServerError,"Internal serve error");
            }
        }

        //[HttpGet("GetPostById")]
        //public async Task<ActionResult<posts>> GetById(long Id)
        //{
        //    try
        //    {
        //        var result = await _unitOfWOrk.PostRepository.GetAsync(Id);
        //        _unitOfWOrk.Commit();
        //        _logger.LogInformation($"Returned post of id {Id} from database");
        //        return Ok(result);
        //    }
        //    catch(Exception ex)
        //    {
        //        _logger.LogError($"Transaction Failed! \nSomething want wrong insede GetByIdAsync action: {ex.Message}");
        //        return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        //    }
        //}

        //POST
        [HttpPost("Post")]
        public async Task<ActionResult<long>> Post([FromBody] PostRequestDTO post)
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
                var result = await _postService.AddAsync(post);
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
        public async Task<ActionResult> Put([FromBody] PostRequestDTO post)
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
                await _postService.UpdateAsync(post);
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
                await _postService.DeleteAsync(id);
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
