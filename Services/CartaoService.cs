
using AutoMapper;

namespace MeuBolsoBackend;

public class CartaoService(ICartaoRepository repository, IAuthService authService, IMapper mapper, IUnitOfWork unitOfWork) : ICartaoService
{
    private readonly ICartaoRepository _repository = repository;
    private readonly IAuthService _authService = authService;
    private readonly IMapper _mapper = mapper;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;

    public async Task<CartaoDto> AdicionarAsync(CartaoManterDto cartaoManterDto)
    {
        var usuarioId = _authService.RecuperarId();

        await VerificarDuplicidade(cartaoManterDto.Nome, cartaoManterDto.Final, usuarioId);

        var cartaoEntity = _mapper.Map<CartaoEntity>(cartaoManterDto, opt => opt.Items["usuarioId"] = usuarioId);

        await _repository.AdicionarAsync(cartaoEntity);
        await _unitOfWork.SaveAsync();

        return _mapper.Map<CartaoDto>(cartaoEntity);
    }

    public async Task AtualizarAsync(long id, CartaoManterDto cartaoManterDto)
    {
        var cartaoEntity = await _repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.RecursoNaoEncontrado.Bind("Cartão"));
        var usuarioId = _authService.RecuperarId();

        await VerificarDuplicidade(cartaoManterDto.Nome, cartaoManterDto.Final, usuarioId);
        _mapper.Map(cartaoManterDto, cartaoEntity);
        await _unitOfWork.SaveAsync();
    }

    public async Task<CartaoDto> RecuperarPorIdAsync(long id)
    {
        var cartaoEntity = await _repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.RecursoNaoEncontrado.Bind("Cartão"));

        return _mapper.Map<CartaoDto>(cartaoEntity);
    }

    public async Task<List<CartaoDto>> RecuperarTodosPorUsuarioIdAsync()
    {
        var usuarioId = _authService.RecuperarId();
        var cartoesEntity = await _repository.RecuperarTodosPorUsuarioIdAsync(usuarioId);

        return _mapper.Map<List<CartaoDto>>(cartoesEntity);
    }

    public async Task RemoverPorIdAsync(long id)
    {
        await _repository.RemoverPorIdAsync(id);
        await _unitOfWork.SaveAsync();
    }

    private async Task VerificarDuplicidade(string nome, string final, long usuarioId)
    {
        if (await _repository.ExistePorNomeEFinalEUsuarioIdAsync(nome, final, usuarioId))
        {
            throw new ConflictException(Message.CartaoDuplicado);
        }
    }
}