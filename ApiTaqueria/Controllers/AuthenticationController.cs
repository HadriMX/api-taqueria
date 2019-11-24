using ApiTaqueria.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ApiTaqueria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly JWT _jwt;

        public AuthenticationController(IOptions<JWT> jwtSettings)
        {
            _jwt = jwtSettings.Value;
        }

        // POST api/login
        [HttpPost("login")]
        public IActionResult Login(Usuario dto)
        {
            var loggedIn = ChecharUsuarios(dto.Username, dto.Pwd);

            if (loggedIn)
            {
                UserToken userToken = CreateUserToken(dto.Username);
                return Ok(userToken);
            }
            else
            {
                return Unauthorized();
            }
        }

        private bool ChecharUsuarios(string username, string pwd)
        {
            if (username == "admin" && pwd == "admin")
                return true;
            else if (username == "mesero1" && pwd == "qwerty")
                return true;
            else if (username == "mesero2" && pwd == "ytrewq")
                return true;
            else
                return false;
        }

        private UserToken CreateUserToken(string username)
        {
            JwtSecurityToken jwtToken = CreateJwtToken(username);

            return new UserToken
            {
                Token = new JwtSecurityTokenHandler().WriteToken(jwtToken),
                Expiration = jwtToken.ValidTo
            };
        }

        private JwtSecurityToken CreateJwtToken(string username)
        {
            var signingKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwt.SigningKey.ToLowerInvariant()));
            DateTime expireDateTime = DateTime.UtcNow.AddMinutes(_jwt.ExpiresInMinutes);

            Claim[] claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString("o"), ClaimValueTypes.DateTime)
            };

            return new JwtSecurityToken(
                issuer: _jwt.Site,
                audience: _jwt.Site,
                expires: expireDateTime,
                claims: claims,
                signingCredentials: new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256)
            );
        }
    }
}