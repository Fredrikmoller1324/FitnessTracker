using FitnessTracker.Entities;
using System.Linq.Expressions;

namespace FitnessTracker.Interfaces
{
    public interface IGeneric<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter, params Expression<Func<TEntity, object>>[] including);
        Task<TEntity> GetByIdAsync(int id);
        TEntity Create(TEntity entity);
        TEntity Update(int id,TEntity entity);
        TEntity Delete(Func<TEntity,bool> predicate);
        bool Exists(Func<TEntity, bool> predicate);
    }
}
