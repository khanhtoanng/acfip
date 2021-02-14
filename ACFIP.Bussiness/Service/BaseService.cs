using ACFIP.Data.Repository;
using ACFIP.Data.UnitOfWork;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ACFIP.Bussiness.Service
{
    public abstract class BaseService<TEntity, TDto> : IBaseService<TEntity, TDto>
         where TEntity : class
         where TDto : class
    {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        protected abstract IGenericRepository<TEntity> _reponsitory { get; }

        public BaseService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _uow = unitOfWork;
            _mapper = mapper;
        }

        public virtual async Task<TDto> CreateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _reponsitory.Add(entity);

            await _uow.SaveAsync();

            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<bool> DeleteAsync(object id)
        {
            if (id != null)
            {
                _reponsitory.Delete(id);

            }
            return await _uow.SaveAsync() > 0;
        }

        public virtual async Task<TDto> UpdateAsync(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto);
            _reponsitory.Update(entity);
            await _uow.SaveAsync();

            return _mapper.Map<TDto>(entity);
        }

        public virtual async Task<TDto> GetByIdAsync(object id)
        {
            if (id != null)
            {
                return _mapper.Map<TDto>(await _reponsitory.GetById(id));
            }
            return null;
        }

        public async Task<IEnumerable<TDto>> GetAsync(int pageIndex = 0, int pageSize = 0, Expression<Func<TEntity, bool>> filter = null, Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, string includeProperties = "")
        {
            return _mapper.Map<IEnumerable<TDto>>(await _reponsitory.Get(pageIndex, pageSize, filter, orderBy, includeProperties));
        }

        public async Task<TDto> GetFirst(Expression<Func<TEntity, bool>> filter = null, string includeProperties = "")
        {
            return _mapper.Map <TDto>( await _reponsitory.GetFirst(filter, includeProperties));
        }
    }
}
