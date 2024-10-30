using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;
[ApiController]
[Route("api/cartoes")]
[Authorize]
public class CartaoController(ICartaoService cartaoService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<CartaoDto>> AdicionarAsync([FromBody] CartaoManterDto cartaoManterDto)
    {
        var cartaoDto = await cartaoService.AdicionarAsync(cartaoManterDto);
        return CreatedAtAction(nameof(RecuperarPorIdAsync), cartaoDto);
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] CartaoManterDto cartaoManterDto)
    {
        await cartaoService.AtualizarAsync(id, cartaoManterDto);

        return NoContent();
    }

    [HttpGet("{id:long}")]
    public async Task<ActionResult<CartaoDto>> RecuperarPorIdAsync(long id)
    {
        var cartaoDto = await cartaoService.RecuperarPorIdAsync(id);

        return Ok(cartaoDto);
    }

    [HttpGet("usuarios")]
    public async Task<ActionResult<CartaoDto>> RecuperarTodosPorUsuarioIdAsync()
    {
        var cartaoDto = await cartaoService.RecuperarTodosPorUsuarioIdAsync();

        return Ok(cartaoDto);
    }

    [HttpDelete("{id:long}")]
    public async Task<IActionResult> RemoverPorIdAsync(long id)
    {
        await cartaoService.RemoverPorIdAsync(id);

        return NoContent();
    }
}