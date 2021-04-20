using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using DataAccess.Models;
using Microsoft.EntityFrameworkCore;

namespace BusinessLayer.Repository
{
    public class OwnerRepository : CrudRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(TeamCityContext repositoryContext) : base(repositoryContext)
        {
        }

        public Task<Owner> GetProductByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.IdOwner == id);
        }
    }
}
