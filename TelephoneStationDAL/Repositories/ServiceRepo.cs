using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Interfaces;
using TelephoneStationDAL.UoW.Realizations;

namespace TelephoneStationDAL.Repositories;
public class ServiceRepo : RepositoryBase<Service>, IServiceRepo
{
    public ServiceRepo(TelephoneStationDbContext context) : base(context)
    {
    }
}
