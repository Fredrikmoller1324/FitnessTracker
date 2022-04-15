using FitnessTracker.Entities;
using FitnessTracker.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FitnessTracker.Data.Repos
{
    public class BaseRepository<TEntity> : IGeneric<TEntity> where TEntity : BaseEntity
    {
        private readonly DataContext _dataContext;
        

        public BaseRepository(DataContext dataContext)
        {
            _dataContext = dataContext ?? throw new ArgumentNullException(nameof(dataContext));
            
        }
        public async Task Create(TEntity entity)
        {
           await _dataContext.Set<TEntity>().AddAsync(entity);
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if(entity == null) throw new KeyNotFoundException();
            _dataContext.Set<TEntity>().Remove(entity);
        }

        public async Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] including)
        {
            var query =  _dataContext.Set<TEntity>().AsQueryable();

            if (including == null) return await query.ToListAsync();

            including.ToList().ForEach(inludeEntity =>
            {
                if (inludeEntity != null) 
                {
                    query = query.Include(inludeEntity);
                } 
            });

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetById(int id)
        {
            var entity = await _dataContext.Set<TEntity>().SingleOrDefaultAsync(entity => entity.Id == id);
            if(entity == null) throw  new KeyNotFoundException();
            return entity;
        }

        public void Update(int id, TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
        }

        //public async Task<IEnumerable<TEntity>> GetAll()
        //{
        //    return await _dataContext.Set<TEntity>().ToListAsync();
            
        //}
    }
}
