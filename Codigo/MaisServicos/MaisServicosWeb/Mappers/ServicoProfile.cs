using AutoMapper;
using Core;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Mappers
{
    public class ServicoProfile : Profile
    {
        public ServicoProfile() 
        {
            CreateMap<ServicoModel, Servico>().ReverseMap();
        }
    }
}
