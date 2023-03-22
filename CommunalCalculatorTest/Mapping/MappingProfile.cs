using AutoMapper;
using DataEF;

namespace Core.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rate, CommunalRate>();
        }
    }
}
