using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;

[ApiController]
[Route("api/pagamentos")]
[Authorize]
public class PagamentoController(IPagamentoService service) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AdicionarAsync([FromBody] PagamentoManterDto pagamentoManterDto)
    {
        var tagDto = await service.AdicionarAsync(pagamentoManterDto);

        return CreatedAtAction(nameof(RecuperarPorIdAsync), tagDto);
    }
    
    [HttpGet("{id:long}")]
    public async Task<IActionResult> RecuperarPorIdAsync(long id)
    {
        return Ok(await service.RecuperarPorIdAsync(id));
    }
}