using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.OrderToCatogory.Commands.CreateOrderToCategory
{
    public record CreateOrderToCategoryCommand : IRequest<int>
    {
        public int OrderId { get; set; }
        public int CategoryId { get; set; }
    }

    public class CreateOrderToCategoryCommandHandler : IRequestHandler<CreateOrderToCategoryCommand, int>
    {
        private readonly IApplicationDbContext _context;


        public CreateOrderToCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateOrderToCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = new OrderToCategorys
            {
                OrderId = request.OrderId,
                CategoryId = request.CategoryId,
            };

            _context.OrderToCategories.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
