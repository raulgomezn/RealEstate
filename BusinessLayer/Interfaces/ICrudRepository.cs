using System.Linq;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    /// <summary>
    /// Patron repositorio
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface ICrudRepository<TEntity> where TEntity : class, new()
    {
        IQueryable<TEntity> GetAll();

        Task<TEntity> AddAsync(TEntity entity);

        Task<TEntity> UpdateAsync(TEntity entity);
    }
}
