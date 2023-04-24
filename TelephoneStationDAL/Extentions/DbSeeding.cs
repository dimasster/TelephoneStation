using Microsoft.EntityFrameworkCore;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Enums;

namespace TelephoneStationDAL.Extentions;
public static class DbSeeding
{
    public static void SeedData(this ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(
            new Account { Id = 1, Login = "user1", Password = "password", UserId = 1 },
            new Account { Id = 2, Login = "user2", Password = "password", UserId = 2 },
            new Account { Id = 3, Login = "user3", Password = "password", UserId = 3 },
            new Account { Id = 4, Login = "user4", Password = "password", UserId = 4 },
            new Account { Id = 5, Login = "user5", Password = "password", UserId = 5 },
            new Account { Id = 6, Login = "admin", Password = "password", UserId = 6 }
        );

        modelBuilder.Entity<User>().HasData(
            new User { Id = 1, Name = "John", PhoneNumber = 123456789, Role = UserRole.Common, Ballance = 0 },
            new User { Id = 2, Name = "Sarah", LastName = "Smith", PhoneNumber = 234567890, Role = UserRole.Common, Ballance = 0 },
            new User { Id = 3, Name = "Alex", PhoneNumber = 345678901, Role = UserRole.Common, Ballance = 0 },
            new User { Id = 4, Name = "Mike", PhoneNumber = 456789012, Role = UserRole.Common, Ballance = 0 },
            new User { Id = 5, Name = "Emily", PhoneNumber = 567890123, Role = UserRole.Common, Ballance = 0 },
            new User { Id = 6, Name = "Admin", PhoneNumber = 678901234, Role = UserRole.Admin, Ballance = 0 }
        );

        modelBuilder.Entity<Service>().HasData(
            new Service { Id = 1, Title = "Service 1", SubscriptionCost = 9.99, CostPerMinute = 0.1 },
            new Service { Id = 2, Title = "Service 2", SubscriptionCost = 14.99, CostPerMinute = 0.05, FreeMinutes = 10 },
            new Service { Id = 3, Title = "Service 3", SubscriptionCost = 19.99, CostPerMinute = 0.2, FreeMinutes = 10 },
            new Service { Id = 4, Title = "Service 4", SubscriptionCost = 24.99, CostPerMinute = 0.15, FreeMinutes = 20 },
            new Service { Id = 5, Title = "Service 5", SubscriptionCost = 29.99, CostPerMinute = 0.25, FreeMinutes = 20 },
            new Service { Id = 6, Title = "Service 6", SubscriptionCost = 39.99, CostPerMinute = 0.2, FreeMinutes = 30 }
        );

        modelBuilder.Entity<SavedUser>().HasData(
            new SavedUser { UserId = 1, TargetId = 2 },
            new SavedUser { UserId = 1, TargetId = 3 },
            new SavedUser { UserId = 2, TargetId = 1 },
            new SavedUser { UserId = 3, TargetId = 2 },
            new SavedUser { UserId = 4, TargetId = 1 }
        );

        SeedCalls(modelBuilder);
        SeedSubscriptions(modelBuilder);
    }
    public static void SeedCalls(this ModelBuilder modelBuilder)
    {
        var random = new Random();

        var callerIds = new[] { 1, 2, 3, 4, 5 };
        var targetIds = new[] { 1, 2, 3, 4, 5 };
        var callStatuses = Enum.GetValues(typeof(CallStatus)).Cast<CallStatus>().ToList();

        for (int i = 0; i < 30; i++)
        {
            int callerId = callerIds[random.Next(callerIds.Length)];
            int targetId = targetIds[random.Next(targetIds.Length)];
            int callTime = random.Next(60, 600);
            CallStatus status = callStatuses[random.Next(callStatuses.Count)];
            double price = random.NextDouble() * 5;
            bool isBought = random.Next() % 2 == 1;

            var call = new Call
            {
                Id = i + 1,
                CallerId = callerId,
                TargetId = targetId,
                CallTime = callTime,
                Status = status
            };

            modelBuilder.Entity<Call>().HasData(call);

            var callReceipt = new CallReceipt
            {
                Id = i + 1,
                UserId = callerId,
                Price = price,
                IsBought = isBought,
                CallId = i + 1,
            };

            modelBuilder.Entity<CallReceipt>().HasData(callReceipt);
        }
    }
    public static void SeedSubscriptions(ModelBuilder modelBuilder)
    {
        Random rnd = new();

        for (int i = 0; i < 6; i++)
        {
            var subscription = new Subscription
            {
                Id = i + 1,
                UserId = i + 1,
                ServiceId = i + 1,
                SubscriptionStartDate = DateTime.Now.AddDays(-rnd.Next(0, 30)),
                SubscriptionEndDate = DateTime.Now.AddMonths(1),
                MinuteOfUsage = rnd.Next(0, 1000)
            };

            modelBuilder.Entity<Subscription>().HasData(subscription);

            var subscriptionReceipt = new SubscriptionReceipt
            {
                Id = i + 31,
                UserId = i + 1,
                SubscriptionId = i + 1,
                Price = rnd.Next(0, 1000),
                IsBought = rnd.Next() % 2 == 1,
                Date = DateTime.Now.AddDays(-rnd.Next(0, 30))
            };

            modelBuilder.Entity<SubscriptionReceipt>().HasData(subscriptionReceipt);
        }
    }
}