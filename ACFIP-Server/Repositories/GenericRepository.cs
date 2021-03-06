using ACFIP_Server.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACFIP_Server.Repositories
{
    public interface IGenericRepository<T> where T : class
    {
        Task<T> GetById(object id);
        Task<T> GetFirst(Expression<Func<T, bool>> filter = null, string includeProperties = "");
        Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
                 Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                 string includeProperties = "",
                 int first = 0, int offset = 0);
        void Insert(T entity);
        void Update(T entity);
        void Delete(object id);
    }
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        internal readonly MainContext _context;
        internal DbSet<T> dbSet;
        public string errorMsg = string.Empty;
        public GenericRepository(MainContext context)
        {
            _context = context;
            dbSet = _context.Set<T>();
        }
        public virtual async Task<IEnumerable<T>> Get(Expression<Func<T, bool>> filter = null,
                Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
                string includeProperties = "",
                int first = 0, int offset = 0)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (offset > 0)
            {
                query = query.Skip(offset);
            }
            if (first > 0)
            {
                query = query.Take(first);
            }
            foreach (var includeProperty in includeProperties.Split
                (new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }
            if (orderBy != null)
            {
                return await orderBy(query).ToListAsync();
            }
            else
            {
                return await query.ToListAsync();
            }
        }
        public virtual async Task<T> GetById(object id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual void Insert(T entity)
        {
            if (entity == null) throw new ArgumentException("entity");
            dbSet.Add(entity);
        }
        public virtual void Update(T entity)
        {
            if (entity == null) throw new ArgumentException("entity");
            dbSet.Attach(entity);
            dbSet.Update(entity);
        }
        public virtual void Delete(object id)
        {
            T entity = dbSet.Find(id);
            dbSet.Attach(entity);
            dbSet.Remove(entity);
        }

        public Task<T> GetFirst(Expression<Func<T, bool>> filter = null, string includeProperties = "")
        {
            IQueryable<T> query = dbSet;
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
