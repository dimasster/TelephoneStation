using Microsoft.EntityFrameworkCore;
using TelephoneStationDAL.Entities;
using TelephoneStationDAL.Extentions;

namespace TelephoneStationDAL;
public class TelephoneStationDbContext : DbContext
{
    DbSet<Account> Accounts { get; set; }
    DbSet<Call> Calls { get; set; }
    DbSet<Receipt> Receiptes { get; set; }
    DbSet<SavedUser> SavedUsers { get; set; }
    DbSet<Service> Services { get; set; }
    DbSet<Subscription> Subscriptions { get; set; }
    DbSet<User> Users { get; set; }

    public TelephoneStationDbContext()
    {
    }

    public TelephoneStationDbContext(DbContextOptions<TelephoneStationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Account>()
            .HasOne(a => a.User)
            .WithOne(u => u.Account)
            .OnDelete(DeleteBehavior.Cascade);

        modelBuilder.Entity<Call>(entity =>
        {
            entity
                .HasOne(o => o.Caller)
                .WithMany(u => u.Calls)
                .HasForeignKey(o => o.CallerId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(o => o.Target)
                .WithMany(u => u.Callers)
                .HasForeignKey(o => o.TargetId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<CallReceipt>(entity =>
        {
            entity
                .HasOne(c => c.Call)
                .WithOne(c => c.Receipt);
        });

        modelBuilder.Entity<Receipt>(entity =>
        {
            entity
                .HasOne(r => r.User)
                .WithMany(u => u.Receipts)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasDiscriminator<string>("ReceiptType")
                .HasValue<Receipt>("Receipt")
                .HasValue<CallReceipt>("CallReceipt")
                .HasValue<SubscriptionReceipt>("SubscriptionReceipt");
        });

        modelBuilder.Entity<SavedUser>(entity =>
        {
            entity.HasKey(d => new { d.UserId, d.TargetId });

            entity
                .HasOne(s => s.User)
                .WithMany(u => u.Contacts)
                .HasForeignKey(o => o.UserId)
                .OnDelete(DeleteBehavior.NoAction);

            entity
                .HasOne(s => s.Target)
                .WithMany(u => u.Contacters)
                .HasForeignKey(o => o.TargetId)
                .OnDelete(DeleteBehavior.NoAction);
        });

        modelBuilder.Entity<Subscription>(entity =>
        {
            entity
                .HasOne(s => s.User)
                .WithOne(u => u.Subscription)
                .OnDelete(DeleteBehavior.Cascade);

            entity
                .HasOne(s => s.Service)
                .WithMany(s => s.Subscriptions)
                .HasForeignKey(s => s.ServiceId)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<SubscriptionReceipt>(entity =>
        {
            entity
                .HasOne(c => c.Subscription)
                .WithOne(c => c.Receipt);
        });

        modelBuilder.SeedData();
    }
}
