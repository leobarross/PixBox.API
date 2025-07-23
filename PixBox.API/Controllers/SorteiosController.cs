using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PixBox.API.Dtos.Sorteio;
using PixBox.API.Services;

namespace PixBox.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SorteiosController : ControllerBase
    {
        private readonly SorteioService _service;

        public SorteiosController(SorteioService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> CriarSorteio([FromBody] SorteioInputDto dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var sorteio = await _service.CriarSorteioAsync(dto.Titulo, dto.Descricao, dto.DataSorteio);

            

            return CreatedAtAction(nameof(ObterPorId), new { id = sorteio.Id }, sorteio);
        }

        [HttpGet]
        public async Task<IActionResult> ListarSorteios()
        {
            var sorteios = await _service.ListarSorteiosAtivosAsync();

            var output = sorteios.Select(s => new SorteioOutputDto
            {
                Id = s.Id,
                Titulo = s.Titulo,
                Descricao = s.Descricao,
                DataSorteio = s.DataSorteio,
                Ativo = s.Ativo,
                CriadoEm = s.CriadoEm
            });

            return Ok(output);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(string id)
        {
            var sorteio = await _service.ObterPorIdAsync(id);

            if (sorteio == null)
                return NotFound();

            var output = new SorteioOutputDto
            {
                Id = sorteio.Id,
                Titulo = sorteio.Titulo,
                Descricao = sorteio.Descricao,
                DataSorteio = sorteio.DataSorteio,
                Ativo = sorteio.Ativo,
                CriadoEm = sorteio.CriadoEm
            };

            return Ok(output);
        }
    }
}
