using AutoMapper;
using Core;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Mappers
{
    public class ServicoPrestadoProfile : Profile
    {
        public ServicoPrestadoProfile()
        {
            CreateMap<ServicoPrestadoViewModel, Servico>().ReverseMap();
        }
    }
}
