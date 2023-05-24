namespace TelephoneStationBLL.DTO;
public class SubscriptionDTO
{
    public int Id { get; set; }
    public UserDTO? User { get; set; }
    public ServiceDTO? Service { get; set; }
    public DateTime SubscriptionStartDate { get; set; }
    public DateTime SubscriptionEndDate { get; set; }
    public int MinuteOfUsage { get; set; }
}