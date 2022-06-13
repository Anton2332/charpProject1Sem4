using Application.Category.Queries.GetCategoryList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Queries.GetCategoryById
{
    public class GetCategoryByIdQuery : IRequest<CategoryDTO>
    {
        public GetCategoryByIdQuery(int id)
        {
            Id = id;
        }

        public int Id { get;  }
    }
}
