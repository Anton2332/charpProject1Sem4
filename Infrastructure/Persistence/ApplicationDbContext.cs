using Application.Common.Interfaces;
using Domain.Entities;
using Infrastructure.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;


namespace Infrastructure.Persistence
{
    public class ApplicationDbContext:DbContext, IApplicationDbContext
    {
        private readonly IMediator _mediator;

        public ApplicationDbContext(
            DbContextOptions<ApplicationDbContext> options,
            IMediator mediator):base(options)
        {
            _mediator = mediator;
        }


        public DbSet<Categorys> Categorys => Set<Categorys>();

        public DbSet<OrderToCategorys> OrderToCategories => Set<OrderToCategorys>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await _mediator.DispatchDomainEvents(this);

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
