using Application.Category.Commands.CreateCategory;
using Application.Category.Commands.DeleteCategory;
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
        private ISender _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateCategoryCommand command)
        {
            return await _mediator.Send(command);
        }

        [HttpDelete("{Id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _mediator.Send(new DeleteCategoryCommand(id));

            return NoContent();
        }


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

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetAllCategory([FromQuery] GetCategoryListQuery query)
        {
            var result = await _mediator.Send(query);
            if (result != null)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
