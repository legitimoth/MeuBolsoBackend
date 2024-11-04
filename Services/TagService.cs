namespace MeuBolsoBackend;

using AutoMapper;


public class TagService(IMapper mapper, ITagRepository repository) : ITagService
{

    public async Task<List<TagDto>> RecuperarTodasAsync()
    {
        var tagsEntity = await repository.RecuperarTodosAsync();

        return mapper.Map<List<TagDto>>(tagsEntity);
    }
}
