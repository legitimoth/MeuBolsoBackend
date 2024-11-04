using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;
[Route("api/usuarios")]
[ApiController]
[Authorize]
public class UsuarioController(IUsuarioService service) : ControllerBase
{
    [HttpGet("{id:long}")]
    public async Task<ActionResult<UsuarioDto>> RecuperarPorIdAsync(long id)
    {
        return Ok(await service.RecuperarPorIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioDto>> AdicionarAsync()
    {
        var usuario = await service.AdicionarAsync();

        return CreatedAtAction(nameof(RecuperarPorIdAsync), usuario);
    }
}
