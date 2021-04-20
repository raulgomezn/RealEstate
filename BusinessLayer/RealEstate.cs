using DataAccess.Models;
using System.Collections.Generic;
using System.Linq;

namespace BusinessLayer
{
    /// <summary>
    /// Clase test
    /// </summary>
    public class RealEstate
    {
        public List<Owner> AllOwner()
        {
            var context = new TeamCityContext();
            return context.Owners.ToList();
        }
    }
}
