using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

[ApiController]
[Route("api/pagamentos")]
[Authorize]
public class PagamentoController(IPagamentoService service, IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TagDto>> AdicionarAsync([FromBody] PagamentoAdicionarDto pagamentoAdicionarDto)
    {
        var tagDto = await service.AdicionarAsync(pagamentoAdicionarDto);

        return CreatedAtAction(nameof(RecuperarPorIdAsync), tagDto);
    }
    
    [HttpPut("{id:long}")]
    public async Task<ActionResult> AtualizarAsync(long id, [FromBody] PagamentoAtualizarDto pagamentoAtualizarDto)
    {
        await service.AtualizarAsync(id, pagamentoAtualizarDto);
        return NoContent();
    }
    
    [HttpGet("{id:long}")]
    public async Task<ActionResult<TagDto>> RecuperarPorIdAsync(long id)
    {
        return Ok(await service.RecuperarPorIdAsync(id));
    }
    
    [HttpGet]
    public async Task<ActionResult<TagDto>> RecuperarTodosAsync()
    {
        return Ok(await service.RecuperarPorUsuarioIdAsync(authService.RecuperarId()));
    }
    
    [HttpPatch("{id:long}/cancelar")]
    public async Task<ActionResult> CancelarAsync(long id)
    {
        await service.CancelarAsync(id);
        
        return Ok();
    }
    
    [HttpDelete("{id:long}")]
    public async Task<ActionResult> RemoverAsync(long id)
    {
        await service.RemoverPorIdAsync(id);
        return NoContent();
    }
}