﻿using FitnessTracker.Entities;
using FitnessTracker.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
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
        public TEntity Create(TEntity entity)
        {
            if (entity == null) return null;

            _dataContext.Attach(entity);
            _dataContext.Set<TEntity>().AddAsync(entity);

            return entity;
        }

        /// <summary>
        ///     Deletes an entity
        /// </summary>
        /// <param name="predicate">A function to test each element for a condition</param>
        /// <returns>The deleted entity or null if deletion was unsuccessful</returns>
        public TEntity Delete(Func<TEntity, bool> predicate)
        {
            if (predicate is null) return null;

            var entity = _dataContext.Set<TEntity>().FirstOrDefault(predicate);

            if (entity is null) return null;

            _dataContext.Set<TEntity>().Remove(entity);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity,bool>> filter = null,
            Func<IQueryable<TEntity>,IIncludableQueryable<TEntity, object>> including = null)
        {
            var query =  _dataContext.Set<TEntity>().AsQueryable();

            if(filter != null)
            {
                query = query.Where(filter);
            }

            if(including != null)
            {
                query = including(query);
            }

            return await query.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            var entity = await _dataContext.Set<TEntity>().SingleOrDefaultAsync(entity => entity.Id == id);
            if(entity == null) throw  new KeyNotFoundException();
            return entity;
        }

        public TEntity Update(int id, TEntity entity)
        {
            _dataContext.Set<TEntity>().Update(entity);
            return entity;
        }

        public bool Exists(Func<TEntity, bool> predicate)
        {
            if (predicate is null)
            {
                return false;
            }

            return _dataContext.Set<TEntity>().AsNoTracking().FirstOrDefault(predicate) is not null;
        }


    }
}
