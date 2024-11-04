namespace MeuBolsoBackend;

public interface ITagService
{
    Task<List<TagDto>> RecuperarTodasAsync();
}
