using ApiTaqueria.Models;
using ApiTaqueria.Persistence;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace ApiTaqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TaqueriaContext _context;
        private readonly JWT _jwt;
        private readonly UserManager<IdentityUser> _userManager;

        public AuthenticationController(TaqueriaContext context, IOptions<JWT> jwtSettings, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _jwt = jwtSettings.Value;
            _userManager = userManager;
        }

        // POST api/register
        [HttpPost("register")]
        public async Task<IActionResult> Insert(Usuario dto)
        {
            var user = new IdentityUser
            {
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = dto.Username
            };

            IdentityResult result = await _userManager.CreateAsync(user, dto.Pwd).ConfigureAwait(false);

            if (result.Succeeded)
            {
                return Ok();
            }
            else
            {
                return BadRequest(result.Errors);
            }
        }
    }
}