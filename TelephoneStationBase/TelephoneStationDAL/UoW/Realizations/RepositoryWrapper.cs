using TelephoneStationDAL.Interfaces;
using TelephoneStationDAL.Repositories;
using TelephoneStationDAL.UoW.Interfaces;

namespace TelephoneStationDAL.UoW.Realizations;
public class RepositoryWrapper : IRepositoryWrapper
{
    readonly TelephoneStationDbContext _context;

    IAccountRepo _accountRepo;

    ICallRepo _callRepo;

    IReceiptRepo _receiptRepo;

    ISavedUserRepo _savedUserRepo;

    IServiceRepo _serviceRepo;

    ISubscriptionRepo _subscriptionRepo;

    IUserRepo _userRepo;

    public RepositoryWrapper(TelephoneStationDbContext context)
    {
        _context = context;
    }

    public IAccountRepo AccountRepo
    {
        get
        {
            _accountRepo ??= new AccountRepo(_context);

            return _accountRepo;
        }
    }

    public ICallRepo CallRepo
    {
        get
        {
            _callRepo ??= new CallRepo(_context);

            return _callRepo;
        }
    }

    public IReceiptRepo ReceiptRepo
    {
        get
        {
            _receiptRepo ??= new ReceiptRepo(_context);

            return _receiptRepo;
        }
    }

    public ISavedUserRepo SavedUserRepo
    {
        get
        {
            _savedUserRepo ??= new SavedUserRepo(_context);

            return _savedUserRepo;
        }
    }

    public IServiceRepo ServiceRepo
    {
        get
        {
            _serviceRepo ??= new ServiceRepo(_context);

            return _serviceRepo;
        }
    }

    public ISubscriptionRepo SubscriptionRepo
    {
        get
        {
            _subscriptionRepo ??= new SubscriptionRepo(_context);

            return _subscriptionRepo;
        }
    }

    public IUserRepo UserRepo
    {
        get
        {
            _userRepo ??= new UserRepo(_context);

            return _userRepo;
        }
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }

    public async Task<int> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync();
    }
}
