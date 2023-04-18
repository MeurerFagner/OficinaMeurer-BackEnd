using AutoMapper;
using OficinaMeurer.Domain.Entidades;
using OficinaMeurer.Domain.ViewModel;

namespace OficinaMeurer.APP.Mapper
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Cliente, ClienteViewModel>().ReverseMap();
        }

    }
}
