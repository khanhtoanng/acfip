using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service
{
    public interface IBaseService<TEntity, TDto>
       where TEntity : class
       where TDto : class
    {
        Task<IEnumerable<TEntity>> GetAsync(int pageIndex = 0, int pageSize = 0, Expression<Func<TEntity, bool>> filter = null,
                                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                                        string includeProperties = "");
        Task<TDto> CreateAsync(TDto dto);
        Task<TDto> UpdateAsync(TDto dto);
        Task<bool> DeleteAsync(object id);
        Task<TDto> GetByIdAsync(object id);
    }
}
