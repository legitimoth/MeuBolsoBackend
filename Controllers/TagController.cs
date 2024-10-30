using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

[ApiController]
[Route("api/tags")]
[Authorize]
public class TagController(ITagService tagService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AdicionarAsync([FromBody] TagManterDto tagManterDto)
    {
        var tagDto = await tagService.AdicionarAsync(tagManterDto);

        return CreatedAtAction(nameof(RecuperarPorIdAsync), tagDto);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> AtualizarAsync(long id, [FromBody] TagManterDto tagManterDto)
    {
        await tagService.AtualizarAsync(id, tagManterDto);

        return NoContent();
    }

    [HttpGet("usuarios/{usuarioId:long}")]
    public async Task<IActionResult> RecuperarTodasPorUsuarioIdAsync(long usuarioId)
    {
        return Ok(await tagService.RecuperarTodasPorUsuarioIdAsync(usuarioId));
    }

    [HttpGet("{id:long}")]
    public async Task<IActionResult> RecuperarPorIdAsync(long id)
    {
        return Ok(await tagService.RecuperarPorIdAsync(id));
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> RemoverPorIdAsync(long id)
    {
        await tagService.RemoverPorIdAsync(id);

        return NoContent();
    }
}
