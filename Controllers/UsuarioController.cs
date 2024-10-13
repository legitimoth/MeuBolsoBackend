using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;
[Route("api/usuarios")]
[ApiController]
public class UsuarioController(IUsuarioService service) : ControllerBase
{

    private readonly IUsuarioService _service = service;

    [HttpGet("{id}")]
    public async Task<ActionResult<UsuarioDto>> RecuperarPorIdAsync(long id)
    {
        return Ok(await _service.RecuperarPorIdAsync(id));
    }

    [HttpPost]
    public async Task<ActionResult<UsuarioDto>> AdicionarAsync()
    {
        var usuario = await _service.AdicionarAsync();

        return CreatedAtAction(nameof(RecuperarPorIdAsync), usuario);
    }
}
