using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

[ApiController]
[Route("api/tags")]
[Authorize]
public class TagController(ITagService tagService, IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TagDto>> AdicionarAsync([FromBody] TagManterDto tagManterDto)
    {
        var tagDto = await tagService.AdicionarAsync(tagManterDto);

        return CreatedAtAction(nameof(RecuperarPorIdAsync), tagDto);
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult> AtualizarAsync(long id, [FromBody] TagManterDto tagManterDto)
    {
        await tagService.AtualizarAsync(id, tagManterDto);

        return NoContent();
    }

    [HttpGet()]
    public async Task<ActionResult<List<TagDto>>> RecuperarTodasAsync()
    {
        return Ok(await tagService.RecuperarTodasPorUsuarioIdAsync(authService.RecuperarId()));
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<TagDto>> RecuperarPorIdAsync(long id)
    {
        return Ok(await tagService.RecuperarPorIdAsync(id));
    }

    [HttpDelete("{id:long}")]
    public async Task<ActionResult> RemoverPorIdAsync(long id)
    {
        await tagService.RemoverPorIdAsync(id);

        return NoContent();
    }
}
