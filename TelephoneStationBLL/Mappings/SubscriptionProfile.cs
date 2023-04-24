using AutoMapper;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;

namespace TelephoneStationBLL.Mappings;
public class SubscriptionProfile : Profile
{
    public SubscriptionProfile()
    {
        CreateMap<Subscription, SubscriptionDTO>()
            .ForPath(s => s.User, c => c.MapFrom(src => src.User))
            .ForPath(s => s.Service, c => c.MapFrom(src => src.Service));
    }
}
