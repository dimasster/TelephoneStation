using System.ComponentModel.DataAnnotations;

namespace TelephoneStationDAL.Entities;
public class SubscriptionReceipt : Receipt
{
    [Required]
    public int SubscriptionId { get; set; }

    public Subscription? Subscription { get; set; }
}
