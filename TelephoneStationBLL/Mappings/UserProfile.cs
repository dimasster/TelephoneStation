using AutoMapper;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;

namespace TelephoneStationBLL.Mappings;
public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDTO>().ReverseMap();
    }
}
