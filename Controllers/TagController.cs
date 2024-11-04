using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

[ApiController]
[Route("api/tags")]
[Authorize]
public class TagController(ITagService tagService) : ControllerBase
{
    [HttpGet()]
    public async Task<ActionResult<List<TagDto>>> RecuperarTodasAsync()
    {
        return Ok(await tagService.RecuperarTodasAsync());
    }
}
