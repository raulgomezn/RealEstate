using Microsoft.AspNetCore.Mvc;
using BusinessLayer;
using BusinessLayer.Interfaces;

namespace RealEstateApi.Controllers
{
    /// <summary>
    /// Api de Real Estate
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class RealEstateController : ControllerBase
    {
        private readonly IOwnerRepository _ownerService;

        /// <summary>
        /// Constructor con inyecion de independecia.
        /// </summary>
        /// <param name="ownerService"></param>
        public RealEstateController(IOwnerRepository ownerService)
        {
            _ownerService = ownerService;
        }

        /// <summary>
        /// Get All Owners
        /// </summary>
        /// <returns></returns>
        [Authorize]
        [HttpGet("getallowners")]
        public IActionResult Getallowners()
        {
            var users = _ownerService.GetAll();
            return Ok(users);
        }
    }
}
