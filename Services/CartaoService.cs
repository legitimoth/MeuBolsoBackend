
using AutoMapper;

namespace MeuBolsoBackend;

public class CartaoService(ICartaoRepository repository, IAuthService authService, IMapper mapper, IUnitOfWork unitOfWork) : ICartaoService
{
    public async Task<CartaoDto> AdicionarAsync(CartaoManterDto cartaoManterDto)
    {
        var usuarioId = authService.RecuperarId();

        await VerificarDuplicidade(cartaoManterDto.Nome, cartaoManterDto.Final, usuarioId);

        var cartaoEntity = mapper.Map<CartaoEntity>(cartaoManterDto, opt => opt.Items["usuarioId"] = usuarioId);

        await repository.AdicionarAsync(cartaoEntity);
        await unitOfWork.SaveAsync();

        return mapper.Map<CartaoDto>(cartaoEntity);
    }

    public async Task AtualizarAsync(long id, CartaoManterDto cartaoManterDto)
    {
        var cartaoEntity = await repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.RecursoNaoEncontrado.Bind("Cartão"));
        var usuarioId = authService.RecuperarId();

        await VerificarDuplicidade(cartaoManterDto.Nome, cartaoManterDto.Final, usuarioId);
        mapper.Map(cartaoManterDto, cartaoEntity);
        await unitOfWork.SaveAsync();
    }

    public async Task<CartaoDto> RecuperarPorIdAsync(long id)
    {
        var cartaoEntity = await repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.RecursoNaoEncontrado.Bind("Cartão"));

        return mapper.Map<CartaoDto>(cartaoEntity);
    }

    public async Task<List<CartaoDto>> RecuperarTodosPorUsuarioIdAsync()
    {
        var usuarioId = authService.RecuperarId();
        var cartoesEntity = await repository.RecuperarTodosPorUsuarioIdAsync(usuarioId);

        return mapper.Map<List<CartaoDto>>(cartoesEntity);
    }

    public async Task RemoverPorIdAsync(long id)
    {
        await repository.RemoverPorIdAsync(id);
        await unitOfWork.SaveAsync();
    }

    private async Task VerificarDuplicidade(string nome, string final, long usuarioId)
    {
        if (await repository.ExistePorNomeEFinalEUsuarioIdAsync(nome, final, usuarioId))
        {
            throw new ConflictException(Message.CartaoDuplicado);
        }
    }
}