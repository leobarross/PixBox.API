using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixBox.API.Dtos.Login;
using PixBox.API.Dtos.Usuario;
using PixBox.API.Services;
using System.Threading.Tasks;

namespace PixBox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly UsuarioService _service;

        public UsuariosController(UsuarioService service)
        {
            _service = service;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginInputDto loginDto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var resultadoLogin = await _service.LoginAsync(loginDto.Telefone, loginDto.Senha);

                return Ok(resultadoLogin);
            }
            catch (ArgumentException ex)
            {
                return Unauthorized(new { status = "fail", error = ex.Message });
            }
        }

        [HttpPost("registrar")]
        public async Task<IActionResult> Registrar([FromBody] UsuarioInputDto usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioCriado = await _service.RegistrarUsuarioAsync(usuario);
                return CreatedAtAction(nameof(ObterPorId), new { id = usuarioCriado.Id }, usuarioCriado);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
            catch (InvalidOperationException ex)
            {
                return Conflict(new { erro = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(string id)
        {
            var usuario = await _service.ObterPorIdAsync(id);

            if (usuario == null)
                return NotFound();

            return Ok(usuario);
        }
    }
}
