using AutoMapper;
using DataEF;

namespace Core.Mapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Rate, CommunalRate>().ReverseMap();

            CreateMap<Result, ServiceResult>()
                .ForMember( s => s.MeterValue, r => r.Ignore())
                .ForMember( s => s.Rate, r => r.Ignore())
                .ForMember(s => s.Normative, r => r.Ignore())
                .ReverseMap();

            CreateMap<DataEF.BillingPeriod, Core.BillingPeriod>().ReverseMap();

            CreateMap<DataEF.MeterValue, Core.MeterValue>().ReverseMap();

            CreateMap<CommunalService, ServiceResult>()
                .ForMember(s => s.BillingPeriod, c => c.Ignore())
                .ForMember(s => s.MeterValue, c => c.Ignore())
                .ForMember(s => s.Rate, c => c.Ignore())
                .ForMember(s => s.Normative, c => c.Ignore());

            CreateMap<ServiceResult, DataEF.MeterValue>()
                .ForMember(m => m.Value, s => s.MapFrom(p => p.MeterValue))
                .ForMember(m => m.ServiceTypeId, s => s.Ignore())
                .ForMember(m => m.BillingPeriodId, s => s.Ignore())
                .ForMember(m => m.Id, s => s.Ignore());

            }
    }
}
