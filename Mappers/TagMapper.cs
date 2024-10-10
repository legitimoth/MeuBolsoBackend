using AutoMapper;

namespace MeuBolsoBackend;

public class TagMapper : Profile
{
    public TagMapper()
    {
        CreateMap<TagEntity, TagDto>();
        CreateMap<TagManterDto, TagEntity>()
        .ForMember(dest => dest.UsuarioId, opt => opt.MapFrom((src, dest, _, context) =>
            {
                if (dest.UsuarioId > 0)
                {
                    return dest.UsuarioId;
                }

                var usuarioId = context.Items["usuarioId"] as long? ?? throw new ArgumentException(Message.UsuarioIdNaoInformadoParaMapeamento);

                return usuarioId;
            }));
    }
}
