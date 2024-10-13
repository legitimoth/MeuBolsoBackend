using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

[ApiController]
[Route("api/tags")]
[Authorize]
public class TagController(ITagService tagService) : ControllerBase
{
    private readonly ITagService _tagService = tagService;

    [HttpPost]
    public async Task<IActionResult> AdicionarAsync([FromBody] TagManterDto tagManterDto)
    {
        var tagDto = await _tagService.AdicionarAsync(tagManterDto);

        return CreatedAtAction(nameof(RecuperarPorIdAsync), tagDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> AtualizarAsync(long id, [FromBody] TagManterDto tagManterDto)
    {
        await _tagService.AtualizarAsync(id, tagManterDto);

        return NoContent();
    }

    [HttpGet("usuarios/{usuarioId}")]
    public async Task<IActionResult> RecuperarTodasPorUsuarioIdAsync(long usuarioId)
    {
        return Ok(await _tagService.RecuperarTodasPorUsuarioIdAsync(usuarioId));
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> RecuperarPorIdAsync(long id)
    {
        return Ok(await _tagService.RecuperarPorIdAsync(id));
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverPorIdAsync(long id)
    {
        await _tagService.RemoverPorIdAsync(id);

        return NoContent();
    }
}
