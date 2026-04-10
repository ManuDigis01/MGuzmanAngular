using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AngularGuzman.Server.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
  
    public class UsuarioController : Controller
    {
        private readonly BL.Usuario _usuario;
        public UsuarioController(BL.Usuario usuario)
        {
            _usuario = usuario;
        }
        [HttpGet]
        [Route("GetAll")]
        [Authorize]
        public IActionResult GetAll()
        {
            ML.Result result = _usuario.GetAll();

            if (result.Correct)
            {
                return Ok(result);
            }

            return BadRequest(result.ErrorMessage);
        }
        [HttpGet]
        [Route("GetById/{IdUsuario}")]
        public IActionResult GetById(int IdUsuario)
        {
            ML.Result result = _usuario.GetById(IdUsuario);

            if (result.Correct)
            {
                return Ok(result);
            }

            return BadRequest(result.ErrorMessage);
        }

        [HttpPost]
        [Route("Add")]
        [Authorize]
        public IActionResult Add([FromBody] ML.Usuario usuario)
        {
            ML.Result result = _usuario.Add(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] ML.Usuario usuario)
        {
            ML.Result result = _usuario.Update(usuario);
            if (result.Correct)
            {
                return Ok(result);
            }
            else
            {
                return BadRequest(result.ErrorMessage);
            }
        }
        [HttpDelete]
        [Route("Delete/{IdUsuario}")]
        public IActionResult Delete(int IdUsuario)
        {
            ML.Result result = _usuario.Delete(IdUsuario);

            if (result.Correct)
            {
                return Ok(result);
            }

            return BadRequest(result.ErrorMessage);
        }

    }
}
