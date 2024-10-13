using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MeuBolsoBackend;
[ApiController]
[Route("api/cartoes")]
[Authorize]
public class CartaoController(ICartaoService cartaoService) : ControllerBase
{
    private readonly ICartaoService _cartaoService = cartaoService;

    [HttpPost]
    public async Task<ActionResult<CartaoDto>> AdicionarAsync([FromBody] CartaoManterDto cartaoManterDto)
    {
        var cartaoDto = await _cartaoService.AdicionarAsync(cartaoManterDto);
        return CreatedAtAction(nameof(RecuperarPorIdAsync), cartaoDto);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Atualizar(long id, [FromBody] CartaoManterDto cartaoManterDto)
    {
        await _cartaoService.AtualizarAsync(id, cartaoManterDto);

        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<CartaoDto>> RecuperarPorIdAsync(long id)
    {
        var cartaoDto = await _cartaoService.RecuperarPorIdAsync(id);

        return Ok(cartaoDto);
    }

    [HttpGet("usuarios")]
    public async Task<ActionResult<CartaoDto>> RecuperarTodosPorUsuarioIdAsync()
    {
        var cartaoDto = await _cartaoService.RecuperarTodosPorUsuarioIdAsync();

        return Ok(cartaoDto);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> RemoverPorIdAsync(long id)
    {
        await _cartaoService.RemoverPorIdAsync(id);

        return NoContent();
    }
}