using AutoMapper;
using Core;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Mappers
{
    public class PrestadorProfile : Profile
    {
        public PrestadorProfile()
        {
            CreateMap<PrestadorViewModel, Pessoa>().ReverseMap();
        }
    }
}
