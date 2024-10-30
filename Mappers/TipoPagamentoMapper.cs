using AutoMapper;

namespace MeuBolsoBackend;

public class TipoPagamentoMapper : Profile
{
    public TipoPagamentoMapper()
    {
        CreateMap<TipoPagamentoEntity, TipoPagamentoDto>().ReverseMap();
    }
}
