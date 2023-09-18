using AutoMapper;
using Core;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Mappers
{
    public class AvaliarClienteProfile : Profile
    {
        public AvaliarClienteProfile()
        {
            CreateMap<AvaliarClienteViewModel, Pessoa>().ReverseMap();
        }
    }
}
