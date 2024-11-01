using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

[ApiController]
[Route("api/pagamentos")]
[Authorize]
public class PagamentoController(IPagamentoService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AdicionarAsync([FromBody] PagamentoAdicionarDto pagamentoAdicionarDto)
    {
        var tagDto = await service.AdicionarAsync(pagamentoAdicionarDto);

        return CreatedAtAction(nameof(RecuperarPorIdAsync), tagDto);
    }
    
    [HttpPut("{id:long}")]
    public async Task<IActionResult> AtualizarAsync(long id, [FromBody] PagamentoAtualizarDto pagamentoAtualizarDto)
    {
        await service.AtualizarAsync(id, pagamentoAtualizarDto);
        return NoContent();
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> RecuperarPorIdAsync(long id)
    {
        return Ok(await service.RecuperarPorIdAsync(id));
    }
    
    [HttpGet]
    public async Task<IActionResult> RecuperarPorUsuarioIdAsync()
    {
        return Ok(await service.RecuperarPorUsuarioIdAsync());
    }
    
    [HttpPatch("{id:long}/cancelar")]
    public async Task<IActionResult> CancelarAsync(long id)
    {
        await service.CancelarAsync(id);
        
        return Ok();
    }
}