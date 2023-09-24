using AutoMapper;
using Core;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Mappers
{
    public class ServicoContratadoProfile : Profile
    {
        public ServicoContratadoProfile()
        {
            CreateMap<ServicoContratadoViewModel, Servicocontratado>().ReverseMap();
        }
    }
}
