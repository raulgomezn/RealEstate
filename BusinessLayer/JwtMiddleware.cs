using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BusinessLayer
{
    /// <summary>
    /// Clase custom para obtener el JWT
    /// </summary>
    public class JwtMiddleware
    {
        private readonly RequestDelegate Next;
        private readonly AppSettings AppSettings;

        public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
        {
            Next = next;
            AppSettings = appSettings.Value;
        }

        public async Task Invoke(HttpContext context, ISecurity service)
        {
            string token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

            if (token != null)
                AttachAccountToContext(context, service, token);

            await Next(context);
        }

        private void AttachAccountToContext(HttpContext context, ISecurity service, string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(AppSettings.Secret);
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out SecurityToken validatedToken);

                var jwtToken = (JwtSecurityToken)validatedToken;
                var accountId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

                context.Items["Account"] = service.GetById(accountId);
            }
            catch
            {
            }
        }
    }
}
