using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using BusinessLayer.Entities;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer
{
    /// <summary>
    /// Negocio de la seguridad
    /// </summary>
    public class Security : ISecurity
    {
        //Lista quemada de usuarios para la autenticación
        private static readonly List<User> users = new List<User>
        {
            new User { Id = 1, Name = "Test", Username = "test", Password = "test" },
            new User { Id = 2, Name = "Raul", Username = "raul", Password = "Raul123!#" },
        };

        private readonly AppSettings _appSettings;

        /// <summary>
        /// Constructor para la seguridad
        /// </summary>
        /// <param name="appSettings"></param>
        public Security(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;
        }

        public AuthResponse Authenticate(AuthRequest model)
        {
            var user = users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            if (user == null) 
                return null;

            var token = GenerateToken(user);

            return new AuthResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public User GetById(int id)
        {
            return users.FirstOrDefault(x => x.Id == id);
        }

        /// <summary>
        /// Generar el token.
        /// </summary>
        /// <param name="user">Objeto usuario.</param>
        /// <returns>El token</returns>
        private string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
                Expires = DateTime.UtcNow.AddMinutes(15),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
