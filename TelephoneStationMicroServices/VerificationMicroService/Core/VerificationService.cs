using System;

namespace VerificationMicroService.Core;

internal class VerificationService
{
    HashSet<ActiveUser> _activeUsers = new HashSet<ActiveUser>();

    public VerificationService()
    {
        new Timer(_ => RegenerateVerificationString(), null, TimeSpan.Zero, TimeSpan.FromMinutes(5));
    }

    void RegenerateVerificationString()
    {
        foreach (var user in _activeUsers)
        {

            user.RegenerateString();
        }
    }

    bool CheckIfUserIsActive(int userId)
    {
        return _activeUsers.Any(user => user.UserId == userId);
    }

    public Verification? AddActiveUser(int userId)
    {
        if (CheckIfUserIsActive(userId))
            return null;

        var newUser = new ActiveUser(userId);
        if (!_activeUsers.Add(newUser))
            return null;

        var verificationDto = new Verification() 
        { 
            Id = newUser.UserId, 
            VerificationString = newUser.VerificationString 
        };

        return verificationDto;
    }

    public bool RemoveActiveUser(int user_id, Verification verification)
    {
        if (VerifyUser(verification) && verification.Id == user_id)
            if (_activeUsers.RemoveWhere(u => u.UserId == user_id) > 0)
                return true;

        return false;
    }

    public bool VerifyUser(Verification verification)
    {
        var activeUser = _activeUsers.FirstOrDefault(u => u.UserId == verification.Id &&
            u.VerificationString == verification.VerificationString);
        if (activeUser == null)
            return false;

        return true;
    }
}