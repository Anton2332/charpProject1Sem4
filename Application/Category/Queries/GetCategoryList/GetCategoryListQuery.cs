using Domain.Entities;
using MediatR;

namespace Application.Category.Queries.GetCategoryList
{
    public record GetCategoryListQuery :IRequest<IEnumerable<CategoryDTO>>
    {
    }
}
