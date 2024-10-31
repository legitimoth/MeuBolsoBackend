namespace MeuBolsoBackend;

using AutoMapper;


public class TagService(IMapper mapper, ITagRepository repository, IUsuarioRepository usuarioRepository, IUnitOfWork unitOfWork, IAuthService authService) : ITagService
{
    public async Task<TagDto> AdicionarAsync(TagManterDto tagManterDto)
    {
        var usuarioId = await RecuperarUsuarioId();

        await VerificarDuplicidade(tagManterDto, usuarioId);

        var tagEntity = mapper.Map<TagEntity>(tagManterDto, opt => opt.Items["usuarioId"] = usuarioId);

        await repository.AdicionarAsync(tagEntity);

        await unitOfWork.SaveAsync();

        return mapper.Map<TagDto>(tagEntity);
    }

    public async Task AtualizarAsync(long id, TagManterDto tagManterDto)
    {
        var tagEntity = await repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.TagNaoEncontrada);

        if(tagManterDto.Nome != tagEntity.Nome){
            await VerificarDuplicidade(tagManterDto, tagEntity.UsuarioId);
        }

        mapper.Map(tagManterDto, tagEntity);

        repository.Atualizar(tagEntity);

        await unitOfWork.SaveAsync();
    }

    public async Task<List<TagDto>> RecuperarTodasPorUsuarioIdAsync(long usuarioId)
    {
        var tags = await repository.RecuperarTodosPorUsuarioIdAsync(usuarioId);

        return mapper.Map<List<TagDto>>(tags);
    }

    public async Task<TagDto> RecuperarPorIdAsync(long id)
    {
        var tag = await repository.RecuperarPorIdAsync(id) ?? throw new NotFoundException(Message.TagNaoEncontrada);

        return mapper.Map<TagDto>(tag);
    }

    private async Task VerificarDuplicidade(TagManterDto tagManterDto, long usuarioId)
    {
        if (await repository.ExistePorNomeEUsuarioIdAsync(tagManterDto.Nome, usuarioId)) {
            throw new ConflictException(Message.TagDuplicada);
        }
    }

    private async Task<long> RecuperarUsuarioId()
    {
        var usuario = await usuarioRepository.RecuperarPorEmailAsync(authService.RecuperarEmail()) ??
            throw new NotFoundException(Message.UsuarioNaoEncontrado);
        return usuario.Id;
    }

    public async Task RemoverPorIdAsync(long id)
    {
        await repository.RemoverPorIdAsync(id);
        await unitOfWork.SaveAsync();
    }
    
    public async Task<List<TagEntity>> ProcessarAsync(List<TagEntity> tagsEntity)
    {
        // Filtra IDs existentes e busca no banco de dados em uma única consulta
        var idsExistentes = tagsEntity.Where(t => t.Id != 0).Select(t => t.Id).ToList();
        var tagsExistentes = await repository.RecuperarPorIdAsync(idsExistentes);

        // Obtém as novas tags (Id == 0)
        var novasTags = tagsEntity.Where(t => t.Id == 0).ToList();

        // Adiciona as novas tags ao contexto
        if (novasTags.Any())
        {
            await repository.AdicionarAsync(novasTags);
        }

        // Retorna todas as tags combinadas, tanto existentes quanto novas
        return tagsExistentes.Concat(novasTags).ToList();
    }
}
