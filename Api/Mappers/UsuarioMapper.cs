using System;
using AutoMapper;
using MeuBolso.Api.Dtos;
using MeuBolso.Api.Entities;

namespace MeuBolso.Api.Mappers;

public class UsuarioMapper : Profile
{
    public UsuarioMapper()
    {
        CreateMap<UsuarioEntity, UsuarioDto>();
        CreateMap<UsuarioManterDto, UsuarioEntity>();
    }
}
