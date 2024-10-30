using AutoMapper;

namespace MeuBolsoBackend;

public class PagamentoMapper : Profile
{
    public PagamentoMapper()
    {
        CreateMap<PagamentoEntity, PagamentoDto>();
        CreateMap<PagamentoManterDto, PagamentoEntity>();
        // .ForMember(v => v.Tags, opt => opt.Ignore())
        // .AfterMap((dto, entity, context) => {
        //     // Converte para entidade
        //     var novasTags = context.Mapper.Map<List<TagEntity>>(dto.Tags);
        //     
        //     //Remove as tags
        //     var removidas = entity.Tags.Where(t => !novasTags.Contains(t));
        //     
        //     foreach (var t in removidas.ToList())
        //         entity.Tags.Remove(t);
        //
        //     // Adiciona tags
        //     var adicionadas = novasTags.Where(t => !entity.Tags.Contains(t));
        //     
        //     foreach (var t in adicionadas)
        //         entity.Tags.Add(t);
        // });
    }
}