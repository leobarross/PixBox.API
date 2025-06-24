using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixBox.API.Dtos;
using PixBox.API.Services;

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

        [HttpPost("registrar")]
        public IActionResult Registrar([FromBody] UsuarioInputDto usuario)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var usuarioCriado = _service.RegistrarUsuario(usuario);
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
        public IActionResult ObterPorId(string id)
        {
            var usuario = _service.ObterPorId(id);

            if (usuario == null)
                return NotFound();

            var dto = new UsuarioDto
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                Telefone = usuario.Telefone,
                Cpf = usuario.Cpf,
                DataNascimento = usuario.DataNascimento,
                Endereco = usuario.Endereco,
                CriadoEm = usuario.CriadoEm
            };

            return Ok(dto);
        }
    }
}
