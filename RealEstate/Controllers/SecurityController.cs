using BusinessLayer;
using Microsoft.AspNetCore.Mvc;

namespace RealEstateApi.Controllers
{
    /// <summary>
    /// Controlador de seguridad
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    public class SecurityController : ControllerBase
    {
        /// <summary>
        /// Dependencia
        /// </summary>
        private ISecurity securityService;

        /// <summary>
        /// Inyeccion de dependencia para el controlador de seguridad
        /// </summary>
        /// <param name="ISecurityService"></param>
        public SecurityController(ISecurity ISecurityService)
        {
            securityService = ISecurityService;
        }

        /// <summary>
        /// Autenticación
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthRequest model)
        {
            var response = securityService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or Password is incorrect." });

            return Ok(response);
        }

        /// <summary>
        /// Test para obtener los usuarios
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var users = securityService.GetAll();
            return Ok(users);
        }
    }
}
