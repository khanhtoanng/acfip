using ACFIP.Data.AppContext;
using ACFIP.Data.Helpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACFIP.Data.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        internal ApplicationContext _context;
        internal DbSet<TEntity> _dbSet;

        public GenericRepository(ApplicationContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(int pageIndex = 0, int pageSize = 0, Expression<Func<TEntity, bool>> filter = null,
             Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;

            if (filter != null)
            {
                query = query.Where(filter);
            }

            foreach (var includeProperty in includeProperties.Split
                                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                query = orderBy(query);
            }

            return pageIndex != 0 && pageSize != 0
                ? await PaginatedList<TEntity>.CreateAsync(query.AsNoTracking(), pageIndex, pageSize)
                : await query.ToListAsync();
        }


        public virtual async Task<TEntity> GetById(object id)
        {
            return await _dbSet.FindAsync(id);
        }


        public virtual void Add(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("entity");
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Added;
            _dbSet.Add(entity);
        }

        public virtual void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("entity");
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _dbSet.Update(entity);
        }

        public virtual void Delete(object id)
        {
            TEntity entityToDelete = _dbSet.Find(id);
            _context.Entry(entityToDelete).State = EntityState.Deleted;
            Delete(entityToDelete);
        }

        public virtual void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentException("entity");
            _dbSet.Attach(entity);
            _context.Entry(entity).State = EntityState.Deleted;
            _dbSet.Remove(entity);
        }


        public Task<TEntity> GetFirst(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<TEntity> query = _dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            foreach (var includeProperty in includeProperties.Split
               (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            return query.FirstOrDefaultAsync();
        }
    }
}
