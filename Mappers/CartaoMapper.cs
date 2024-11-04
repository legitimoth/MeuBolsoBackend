using AutoMapper;

namespace MeuBolsoBackend;

public class CartaoMapper : Profile
{
    public CartaoMapper()
    {
        CreateMap<CartaoEntity, CartaoDto>();
        CreateMap<CartaoManterDto, CartaoEntity>();
    }
}