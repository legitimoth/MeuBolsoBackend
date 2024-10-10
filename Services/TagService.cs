namespace MeuBolsoBackend;

using AutoMapper;


public class TagService(IMapper mapper, ITagRepository repository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IAuthService authService) : ITagService
{
    private readonly IMapper _mapper = mapper;
    private readonly ITagRepository _repository = repository;
    private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
    private readonly IUnitOfWork _unitOfWork = unitOfWork;
    private readonly IAuthService _authService = authService;

    public async Task<TagDto> AdicionarAsync(TagManterDto tagManterDto)
    {
        var usuarioId = await RecuperarUsuarioId();

        await VerificarDuplicidade(tagManterDto, usuarioId);

        var tagEntity = _mapper.Map<TagEntity>(tagManterDto, opt => opt.Items["usuarioId"] = usuarioId);

        await _repository.AdicionarAsync(tagEntity);

        await _unitOfWork.SaveAsync();

        return _mapper.Map<TagDto>(tagEntity);
    }

    public async Task AtualizarAsync(long id, TagManterDto tagManterDto)
    {
        var tagEntity = await _repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.TagNaoEncontrada);

        if(tagManterDto.Nome != tagEntity.Nome){
            await VerificarDuplicidade(tagManterDto, tagEntity.UsuarioId);
        }

        _mapper.Map(tagManterDto, tagEntity);

        _repository.Atualizar(tagEntity);

        await _unitOfWork.SaveAsync();
    }

    public async Task<List<TagDto>> RecuperarTodasPorUsuarioIdAsync(long usuarioId)
    {
        var tags = await _repository.RecuperarTodosPorUsuarioIdAsync(usuarioId);

        return _mapper.Map<List<TagDto>>(tags);
    }

    public async Task<TagDto> RecuperarPorIdAsync(long id)
    {
        var tag = await _repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.TagNaoEncontrada);

        return _mapper.Map<TagDto>(tag);
    }

    private async Task VerificarDuplicidade(TagManterDto tagManterDto, long usuarioId)
    {
        if (await _repository.ExistePorNomeEUsuarioIdAsync(tagManterDto.Nome, usuarioId)) {
            throw new ConflictException(Message.TagDuplicada);
        }
    }

    private async Task<long> RecuperarUsuarioId()
    {
        var usuario = await _usuarioRepository.RecuperarPorEmailAsync(_authService.RecuperarEmail()) ??
            throw new NotFoundException(Message.UsuarioNaoEncontrado);
        return usuario.Id;
    }

    public async Task RemoverPorIdAsync(long id)
    {
        await _repository.RemoverPorIdAsync(id);
        await _unitOfWork.SaveAsync();
    }
}
