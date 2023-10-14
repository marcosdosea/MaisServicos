using AutoMapper;
using Core;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Mappers
{
    public class AreaDeAtuacaoProfile : Profile
    {
        public AreaDeAtuacaoProfile()
        {
            CreateMap<AreaDeAtuacaoViewModel, Areadeatuacao>().ReverseMap();
        }
    }
}
