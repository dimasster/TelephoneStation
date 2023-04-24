using AutoMapper;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;

namespace TelephoneStationBLL.Mappings;
public class ReceiptProfile : Profile
{
    public ReceiptProfile()
    {
        CreateMap<CallReceipt, ReceiptDTO>()
            .ForMember(r => r.Type, c => c.MapFrom(src => "call receipt"))
            .ForPath(r => r.Datails, c => c
                .MapFrom(r => r.CallId));
        CreateMap<SubscriptionReceipt, ReceiptDTO>()
            .ForMember(r => r.Type, c => c.MapFrom(src => "subscription receipt"))
            .ForPath(r => r.Datails, c => c
                .MapFrom(r => r.SubscriptionId));
    }
}
