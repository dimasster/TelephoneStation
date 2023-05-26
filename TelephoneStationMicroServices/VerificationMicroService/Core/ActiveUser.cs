namespace VerificationMicroService.Core;

internal class ActiveUser
{
    public int UserId { get; set; }

    //string like access@dddd.dddd.dddd
    public string VerificationString { get; set; }

    int seed;

    Random _random = new Random();

    public ActiveUser(int userId)
    {
        UserId = userId;
        VerificationString = "access@" + _random.Next()%10000 + "." + _random.Next() % 10000 + "." + _random.Next() % 10000;
    }

    public void RegenerateString()
    {
        int multiplier = 12917981;
        VerificationString = "access@" + (seed += multiplier * seed % 10000) + "." + (seed += multiplier * seed % 10000) + "." + (seed += multiplier * seed % 10000);
    }
}
