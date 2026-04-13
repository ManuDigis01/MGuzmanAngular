using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AngularGuzman.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly BL.Login _login;

        public AuthController(BL.Login login)
        {
            _login = login;
        }

        [HttpPost]
        public IActionResult Login([FromBody] ML.Login request)
        {
            var result = _login.Session(request.Email, request.Password);

            if (!result.Correct)
            {
                return Unauthorized(result);
            }

            // ✅ OBTENER USUARIO
            var usuario = (ML.Usuario)result.Object;

            // 🔐 CLAVE
            var key = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes("EstaEsUnaClaveSuperSegura1234567890"));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 📌 CLAIMS (AQUÍ VA EL ROLE)
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Email),
                new Claim(ClaimTypes.Role, usuario.Role.Nombre) // ✅ ROLE
            };

            // 🎟️ TOKEN
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            return Ok(new
            {
                token = jwt
            });
        }
    }
}