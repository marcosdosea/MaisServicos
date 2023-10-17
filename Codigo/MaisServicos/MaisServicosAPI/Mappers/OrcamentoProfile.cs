using AutoMapper;
using Core;
using MaisServicosWeb.Models;

namespace MaisServicosWeb.Mappers
{
    public class OrcamentoProfile : Profile
    {
        public OrcamentoProfile()
        {
            CreateMap<OrcamentoViewModel, Orcamento>().ReverseMap();
        }
    }
}
