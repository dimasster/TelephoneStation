using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Interfaces;
using TelephoneStationDAL.UoW.Realizations;

namespace TelephoneStationDAL.Repositories;
public class AccountRepo : RepositoryBase<Account>, IAccountRepo
{
    public AccountRepo(TelephoneStationDbContext context) : base(context)
    {
    }
}
