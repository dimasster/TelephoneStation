using AutoMapper;
using TelephoneStationBLL.DTO;
using TelephoneStationDAL.Entities;

namespace TelephoneStationBLL.Mappings;

public class AccountProfile: Profile
{
    public AccountProfile()
    {
        CreateMap<Account, AccountDTO>().ReverseMap();
    }
}
