using DAL_Project2.Entitys;
using DAL_Project2.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_Project2.Repository
{
    public class GenericRepository<TEntity> : IRepository<TEntity> where TEntity : Entity, new()
    {

        protected readonly DBContext _databaseContext;

        protected readonly DbSet<TEntity> _table;

        public bool AutoSaveChanges { get; set; } = true;

        public GenericRepository(DBContext dbContext)
        {
            _databaseContext = dbContext;
            _table = _databaseContext.Set<TEntity>();
        }

        public IQueryable<TEntity> Items => _table;

        public virtual async Task RemoveAsync(int id, CancellationToken Cancel = default)
        {
            _databaseContext.Remove(new TEntity { Id = id });

            if (AutoSaveChanges)
                await _databaseContext.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => _table.ToList();

        public virtual async Task<TEntity> GetByIdAsync(int id, CancellationToken Cancel = default)
            => await Items.SingleOrDefaultAsync(item => item.Id == id, Cancel).ConfigureAwait(false);

        public virtual async Task AddAsync(TEntity entity, CancellationToken Cancel = default)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            await _table.AddAsync(entity);

            if (AutoSaveChanges)
                await _databaseContext.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }

        public virtual async Task UpdateAsync(TEntity entity, CancellationToken Cancel = default)
        {
            if (entity is null) throw new ArgumentNullException(nameof(entity));
            _databaseContext.Entry(entity).State = EntityState.Modified;

            if (AutoSaveChanges)
                await _databaseContext.SaveChangesAsync(Cancel).ConfigureAwait(false);
        }
    }
}
