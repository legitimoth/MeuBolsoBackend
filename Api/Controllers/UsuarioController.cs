using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeuBolso.Api.Dtos;
using MeuBolso.Api.Interfaces.Services;

namespace MeuBolso.Api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    [Authorize]
    public class UsuarioController(IUsuarioService service) : ControllerBase
    {

        private readonly IUsuarioService _service = service;

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> GetById(long id)
        {
            var usuario = await _service.RecuperarPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Post([FromBody] UsuarioManterDto dto)
        {
            var usuario = await _service.AddAsync(dto);

            return CreatedAtAction(nameof(GetById), new { id = usuario.Id }, usuario);
        }
    }
}
