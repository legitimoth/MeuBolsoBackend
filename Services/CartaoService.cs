
using AutoMapper;

namespace MeuBolsoBackend;

public class CartaoService(ICartaoRepository repository, IMapper mapper, IUnitOfWork unitOfWork) : ICartaoService
{
    public async Task<CartaoDto> AdicionarAsync(CartaoManterDto cartaoManterDto)
    {
        await VerificarDuplicidade(cartaoManterDto.Nome, cartaoManterDto.Final);
        
        var cartaoEntity = mapper.Map<CartaoEntity>(cartaoManterDto);

        await repository.AdicionarAsync(cartaoEntity);
        await unitOfWork.SaveAsync();

        return mapper.Map<CartaoDto>(cartaoEntity);
    }

    public async Task AtualizarAsync(long id, CartaoManterDto cartaoManterDto)
    {
        var cartaoEntity = await repository.RecuperarPorIdAsync(id) ?? 
                           throw new NotFoundException(Message.CartaoNaoEncontrado);
        

        await VerificarDuplicidade(cartaoManterDto.Nome, cartaoManterDto.Final);
        mapper.Map(cartaoManterDto, cartaoEntity);
        await unitOfWork.SaveAsync();
    }

    public async Task<CartaoDto> RecuperarPorIdAsync(long id)
    {
        var cartaoEntity = await repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.RecursoNaoEncontrado.Bind("Cartão"));

        return mapper.Map<CartaoDto>(cartaoEntity);
    }

    public async Task<List<CartaoDto>> RecuperarTodosAsync()
    {
        var cartoesEntity = await repository.RecuperarTodosAsync();

        return mapper.Map<List<CartaoDto>>(cartoesEntity);
    }

    public async Task RemoverPorIdAsync(long id)
    {
        var cartaoEntity = await repository.RecuperarPorIdAsync(id) ??
                             throw new NotFoundException(Message.CartaoNaoEncontrado);
        
        repository.RemoverAsync(cartaoEntity);
        await unitOfWork.SaveAsync();
    }

    private async Task VerificarDuplicidade(string nome, string final)
    {
        if (await repository.ExistePorNomeEFinalAsync(nome, final))
        {
            throw new ConflictException(Message.CartaoDuplicado);
        }
    }
}