using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Interfaces;
using TelephoneStationDAL.UoW.Realizations;

namespace TelephoneStationDAL.Repositories;
public class UserRepo : RepositoryBase<User>, IUserRepo
{
    public UserRepo(TelephoneStationDbContext context) : base(context)
    {
    }
}