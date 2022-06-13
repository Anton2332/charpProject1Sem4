using Domain.Entities;
using MediatR;

namespace Application.Category.Queries.GetCategoryList
{
    public class GetCategoryListQuery:IRequest<IEnumerable<CategoryDTO>>
    {
    }
}
