using BusinessLayer;

namespace BusinessLayer
{
    public class AuthResponse : User
    {
        /// <summary>
        /// Token para la autenticación.
        /// </summary>
        public string Token { get; set; }

        public AuthResponse(User user, string token)
        {
            Id = user.Id;
            Name = user.Name;
            Username = user.Username;
            Token = token;
        }
    }
}
