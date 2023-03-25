using AutoMapper;
using DataEF;

namespace Core.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rate, CommunalRate>().ReverseMap();
            CreateMap<Result, ServiceResult>().ForMember( s => s.MeterValue, r => r.Ignore()).ReverseMap();
            CreateMap<DataEF.BillingPeriod, Core.BillingPeriod>().ReverseMap();
            CreateMap<DataEF.MeterValue, Core.MeterValue>().ReverseMap();
            CreateMap<CommunalService, ServiceResult>()
                .ForMember(s => s.BillingPeriod, c => c.Ignore())
                .ForMember(s => s.MeterValue, c => c.Ignore());
            }
    }
}
