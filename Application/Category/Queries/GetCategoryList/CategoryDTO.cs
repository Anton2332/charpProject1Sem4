using Application.Common.Mappings;
using Domain.Entities;
namespace Application.Category.Queries.GetCategoryList
{
    public class CategoryDTO : IMapFrom<Categorys>
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
}
