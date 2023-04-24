using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelephoneStationDAL.Entities;
public class Subscription
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    public int ServiceId { get; set; }

    public DateTime SubscriptionStartDate { get; set; } = DateTime.Now;

    public DateTime SubscriptionEndDate { get; set; } = DateTime.Now.AddMonths(1);

    public int MinuteOfUsage { get; set; } = 0;

    public User? User { get; set; }

    public Service? Service { get; set; }

    public SubscriptionReceipt? Receipt { get; set; }
}
