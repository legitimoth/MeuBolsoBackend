namespace MeuBolsoBackend;
public interface ICartaoService
{
    Task<CartaoDto> AdicionarAsync(CartaoManterDto cartaoManterDto);
    Task AtualizarAsync(long id, CartaoManterDto cartaoManterDto);
    Task<CartaoDto> RecuperarPorIdAsync(long id);
    Task RemoverPorIdAsync(long id);
    Task<List<CartaoDto>> RecuperarTodosPorUsuarioIdAsync();
}