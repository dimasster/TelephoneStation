using TelephoneStationBLL.DTO;

namespace TelephoneStationBLL.Services;

public class AuthorizationService
{
    class ActiveUser
    {
        public int UserId { get; set; }
        public int VerificationString { get; set; }

        public ActiveUser(int userId)
        {
            UserId = userId;
            VerificationString = new Random().Next();
        }
    }

    HashSet<ActiveUser> _activeUsers = new HashSet<ActiveUser>();

    public AuthorizationService()
    {
        new Timer(_ => RegenerateVerificationString(), null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
    }

    void RegenerateVerificationString()
    {
        foreach (var user in _activeUsers)
        {
            user.VerificationString = CalculateRandom(user.VerificationString);
        }
    }

    int CalculateRandom(int seed)
    {
        return seed * 12345 + 12345;
    }

    public bool CheckIfUserIsActive(int userId)
    {
        return _activeUsers.Any(user => user.UserId == userId);
    }

    public VerificationDTO? AddActiveUser(int userId)
    {
        if (CheckIfUserIsActive(userId))
            return null;

        var newUser = new ActiveUser(userId);
        if (!_activeUsers.Add(newUser))
            return null;

        var verificationDto = new VerificationDTO() { Id = newUser.UserId, VerificationString = newUser.VerificationString };

        return verificationDto;
    }

    public bool RemoveActiveUser(int user_id, VerificationDTO verification)
    {
        if((VerifyUser(verification) && verification.Id == user_id) || (/*todo true if user is admin*/true))
            if (_activeUsers.RemoveWhere(u => u.UserId == user_id) > 0)
                    return true;

        return false;
    }

    public bool VerifyUser(VerificationDTO verification)
    {
        var activeUser = _activeUsers.FirstOrDefault(u => u.UserId == verification.Id &&
            u.VerificationString == verification.VerificationString);
        if (activeUser == null)
            return false;

        return true;
    }
}
