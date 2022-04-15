using FitnessTracker.Entities;
using System.Linq.Expressions;

namespace FitnessTracker.Interfaces
{
    public interface IGeneric<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> GetAll(params Expression<Func<TEntity, object>>[] including);
        Task<TEntity> GetById(int id);
        Task Create(TEntity entity);
        void Update(int id,TEntity entity);
        Task Delete(int id);
    }
}
