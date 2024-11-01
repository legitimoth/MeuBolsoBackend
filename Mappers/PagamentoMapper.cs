using AutoMapper;

namespace MeuBolsoBackend;

public class PagamentoMapper : Profile
{
    public PagamentoMapper()
    {
        CreateMap<PagamentoEntity, PagamentoDto>();
        CreateMap<PagamentoAdicionarDto, PagamentoEntity>();
        CreateMap<PagamentoAtualizarDto, PagamentoEntity>();
    }
}