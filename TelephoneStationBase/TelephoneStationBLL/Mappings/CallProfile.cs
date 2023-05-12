using AutoMapper;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;

namespace TelephoneStationBLL.Mappings;
public class CallProfile: Profile
{
    public CallProfile() 
    {
        CreateMap<Call, CallDTO>().ReverseMap();
    }
}
