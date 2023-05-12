namespace TelephoneStationBLL.DTO;
public class ServiceDTO
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public double SubscriptionCost { get; set; }
    public double CostPerMinute { get; set; }
    public int FreeMinutes { get; set; }
}
