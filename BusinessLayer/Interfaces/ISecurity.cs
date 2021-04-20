using System.Collections.Generic;

namespace BusinessLayer
{
    /// <summary>
    /// Interfas para la seguridad.
    /// </summary>
    public interface ISecurity
    {
        AuthResponse Authenticate(AuthRequest model);
        IEnumerable<User> GetAll();
        User GetById(int id);
    }
}
