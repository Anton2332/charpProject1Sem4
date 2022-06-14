using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Category.Commands.DeleteCategory
{
    public record DeleteCategoryCommand:IRequest
    {
        public DeleteCategoryCommand(int id)
        {
            Id = id;
        }

        public int Id { get; }
    }


    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly IApplicationDbContext _context;

        public DeleteCategoryCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Categorys
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new FileNotFoundException(nameof(Categorys) + request.Id);
            }

            _context.Categorys.Remove(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
