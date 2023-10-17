using AutoMapper;
using Core;
using MaisServicosAPI.Models;

namespace MaisServicosAPI.Mappers
{
    public class PrestadorProfile : Profile
    {
        public PrestadorProfile() 
        { 
            CreateMap<PrestadorViewModel , Pessoa> ().ReverseMap();
        }
    }
}
