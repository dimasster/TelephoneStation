using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Interfaces;
using TelephoneStationDAL.UoW.Realizations;

namespace TelephoneStationDAL.Repositories;
public class SavedUserRepo : RepositoryBase<SavedUser>, ISavedUserRepo
{
    public SavedUserRepo(TelephoneStationDbContext context) : base(context)
    {
    }
}
