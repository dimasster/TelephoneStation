using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Interfaces;
using TelephoneStationDAL.UoW.Realizations;

namespace TelephoneStationDAL.Repositories;
public class ReceiptRepo : RepositoryBase<Receipt>, IReceiptRepo
{
    public ReceiptRepo(TelephoneStationDbContext context) : base(context)
    {
    }
}
