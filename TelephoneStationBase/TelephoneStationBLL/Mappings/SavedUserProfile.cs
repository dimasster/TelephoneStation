using AutoMapper;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;

namespace TelephoneStationBLL.Mappings;

public class SavedUserProfile : Profile
{
    public SavedUserProfile()
    {
        CreateMap<SavedUser, SavedUserRequestDTO>().ReverseMap();
    }
}
