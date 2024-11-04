using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

[ApiController]
[Route("api/pagamentos")]
[Authorize]
public class PagamentoController(IPagamentoService service) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TagDto>> AdicionarAsync([FromBody] PagamentoManterDto pagamentoManterDto)
    {
        var tagDto = await service.AdicionarAsync(pagamentoManterDto);

        return CreatedAtAction(nameof(RecuperarPorIdAsync), tagDto);
    }
    
    [HttpPut("{id:long}")]
    public async Task<ActionResult> AtualizarAsync(long id, [FromBody] PagamentoManterDto pagamentoManterDto)
    {
        await service.AtualizarAsync(id, pagamentoManterDto);
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
        return Ok(await service.RecuperarTodosAsync());
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