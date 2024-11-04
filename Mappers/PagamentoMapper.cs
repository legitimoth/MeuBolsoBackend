using AutoMapper;

namespace MeuBolsoBackend;

public class PagamentoMapper : Profile
{
    public PagamentoMapper()
    {
        CreateMap<PagamentoEntity, PagamentoDto>();
        CreateMap<PagamentoManterDto, PagamentoEntity>()
            .ForMember(dest => dest.Tags, opt => opt.Ignore());
    }
}