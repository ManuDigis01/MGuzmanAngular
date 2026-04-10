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

            // ❌ Si credenciales incorrectas
            if (!result.Correct)
            {
                return Unauthorized(result);
            }

            // 🔐 CLAVE SECRETA
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("EstaEsUnaClaveSuperSegura1234567890"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // 📌 Claims (datos dentro del token)
            var claims = new[]
            {
        new Claim(ClaimTypes.Name, request.Email)
    };

            // 🎟️ Crear token
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: creds
            );

            // 🔄 Convertir a string
            var jwt = new JwtSecurityTokenHandler().WriteToken(token);

            // ✅ Respuesta
            return Ok(new
            {
                token = jwt
            });
        }
    }
}