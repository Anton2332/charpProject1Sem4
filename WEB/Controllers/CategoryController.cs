using Application.Category.Queries.GetCategoryById;
using Application.Category.Queries.GetCategoryList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController:ControllerBase
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();

        //[HttpGet]
        //public async Task<ActionResult<int>> Get(int id)
        //{
        //    return Ok(id);
        //}


        [HttpGet("{id}")]
        public async Task<ActionResult<CategoryDTO>> GetCategoryById(int id)
        {
            var value = new GetCategoryByIdQuery(id);
            var category = await _mediator.Send(value);
            if (category == null)
            {
                return NotFound();
            }

            return Ok(category);
        }

        //[HttpGet]
        //public async Task<ActionResult<CategoryDTO>> GetAllCategory([FromQuery] GetCategoryListQuery query)
        //{
        //    var result = await Mediator.Send(query);
        //    if (result != null)
        //    {
        //        return Ok(result);
        //    }
        //    else
        //    {
        //        return BadRequest();
        //    }
        //}

        //[HttpGet]
        //public async Task<IActionResult<CategoryDTO> Get([FromQueryAttribute] GetCategoryListQuery query)
        //{
        //    return await Mediator.Send(query);
        //}
    }
}
