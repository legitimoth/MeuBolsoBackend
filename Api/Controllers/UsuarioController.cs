using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MeuBolso.Api.Dtos;
using MeuBolso.Api.Interfaces.Services;

namespace MeuBolso.Api.Controllers
{
    [Route("api/usuarios")]
    [ApiController]
    public class UsuarioController(IUsuarioService service) : ControllerBase
    {

        private readonly IUsuarioService _service = service;

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDto>> RecuperarPorIdAsync(long id)
        {
            var usuario = await _service.RecuperarPorIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioDto>> Adicionar()
        {
            var usuario = await _service.AddAsync();

            return CreatedAtAction(nameof(RecuperarPorIdAsync), new { id = usuario.Id }, usuario);
        }
    }
}
