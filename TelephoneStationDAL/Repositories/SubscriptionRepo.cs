using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Interfaces;
using TelephoneStationDAL.UoW.Realizations;

namespace TelephoneStationDAL.Repositories;
public class SubscriptionRepo : RepositoryBase<Subscription>, ISubscriptionRepo
{
    public SubscriptionRepo(TelephoneStationDbContext context) : base(context)
    {
    }
}