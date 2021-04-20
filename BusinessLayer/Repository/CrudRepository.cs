using System;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccess.Models;

namespace BusinessLayer.Repository
{
    public class CrudRepository<TEntity> : ICrudRepository<TEntity> where TEntity : class, new()
    {
        protected readonly TeamCityContext RepositoryContext;

        public CrudRepository(TeamCityContext repositoryPatternDemoContext)
        {
            RepositoryContext = repositoryPatternDemoContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            try
            {
                return RepositoryContext.Set<TEntity>();
            }
            catch (Exception ex)
            {
                throw new Exception($"Couldn't retrieve entities: {ex.Message}");
            }
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                await RepositoryContext.AddAsync(entity);
                await RepositoryContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {ex.Message}");
            }
        }

        public async Task<TEntity> UpdateAsync(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }

            try
            {
                RepositoryContext.Update(entity);
                await RepositoryContext.SaveChangesAsync();

                return entity;
            }
            catch (Exception ex)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {ex.Message}");
            }
        }
    }
}
