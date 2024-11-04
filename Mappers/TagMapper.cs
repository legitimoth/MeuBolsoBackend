using AutoMapper;

namespace MeuBolsoBackend;

public class TagMapper : Profile
{
    public TagMapper()
    {
        CreateMap<TagEntity, TagDto>().ReverseMap();
    }
}
