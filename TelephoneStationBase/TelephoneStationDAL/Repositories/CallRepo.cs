using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Interfaces;
using TelephoneStationDAL.UoW.Realizations;

namespace TelephoneStationDAL.Repositories;
public class CallRepo : RepositoryBase<Call>, ICallRepo
{
    public CallRepo(TelephoneStationDbContext context) : base(context)
    {
    }
}