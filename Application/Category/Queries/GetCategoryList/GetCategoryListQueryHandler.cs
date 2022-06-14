using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Application.Category.Queries.GetCategoryList
{
    public class GetCategoryListQueryHandler : IRequestHandler<GetCategoryListQuery, IEnumerable<CategoryDTO>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetCategoryListQueryHandler(IApplicationDbContext context,IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IEnumerable<CategoryDTO>> Handle(GetCategoryListQuery request, CancellationToken cancellationToken)
        {
            var value = await _context.Categorys
                //.OrderBy(x => x.Name)
                .ProjectTo<CategoryDTO>(_mapper.ConfigurationProvider)
                .ToListAsync();
            return value;
            //return value?.Select(_mapper.Map<Categorys,CategoryDTO>);
        }
    }
}
