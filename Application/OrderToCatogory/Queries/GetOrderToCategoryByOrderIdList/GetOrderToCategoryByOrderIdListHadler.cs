using Application.Common.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderToCatogory.Queries.GetOrderToCategoryByOrderIdList
{
    public class GetOrderToCategoryByOrderIdListHadler : IRequestHandler<GetOrderToCategoryByOrderIdListQuery, IEnumerable<OrderToCategoryDTO>>
    {

        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetOrderToCategoryByOrderIdListHadler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        public async Task<IEnumerable<OrderToCategoryDTO>> Handle(GetOrderToCategoryByOrderIdListQuery request, CancellationToken cancellationToken)
        {
            return await _context.OrderToCategories
                .Where(x => x.OrderId == request.CategoryId)
                .ProjectTo<OrderToCategoryDTO>(_mapper.ConfigurationProvider).ToListAsync();
        }
    }
}
