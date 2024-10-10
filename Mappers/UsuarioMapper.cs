using AutoMapper;

namespace MeuBolsoBackend;

public class UsuarioMapper : Profile
{
    public UsuarioMapper()
    {
        CreateMap<UsuarioEntity, UsuarioDto>();
        CreateMap<UsuarioManterDto, UsuarioEntity>();
    }
}
