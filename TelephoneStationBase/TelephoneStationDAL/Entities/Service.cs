using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelephoneStationDAL.Entities;
public class Service
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(30)]
    public string? Title { get; set; }

    [Required]
    [Column(TypeName = "money")]
    //cost per day
    public double SubscriptionCost { get; set; }

    [Required]
    [Column(TypeName = "money")]
    public double CostPerMinute { get; set; }

    public int FreeMinutes { get; set; } = 0;

    public List<Subscription> Subscriptions { get; set; } = new List<Subscription>();
}
