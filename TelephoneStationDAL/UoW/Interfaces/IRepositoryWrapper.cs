using TelephoneStationDAL.Interfaces;

namespace TelephoneStationDAL.UoW.Interfaces;
public interface IRepositoryWrapper
{
    IAccountRepo AccountRepo { get; }
    ICallRepo CallRepo { get; }
    IReceiptRepo ReceiptRepo { get; }
    ISavedUserRepo SavedUserRepo { get; }
    IServiceRepo ServiceRepo { get; }
    ISubscriptionRepo SubscriptionRepo { get; }
    IUserRepo UserRepo { get; }

    public int SaveChanges();

    public Task<int> SaveChangesAsync();
}
