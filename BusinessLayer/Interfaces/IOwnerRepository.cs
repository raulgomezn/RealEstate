using System.Threading.Tasks;
using DataAccess.Models;

namespace BusinessLayer.Interfaces
{
    public interface IOwnerRepository : ICrudRepository<Owner>
    {
        Task<Owner> GetProductByIdAsync(int id);
    }
}
