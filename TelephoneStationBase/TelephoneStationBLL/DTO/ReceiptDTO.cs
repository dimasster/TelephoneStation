namespace TelephoneStationBLL.DTO;
public class ReceiptDTO
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public bool IsBought { get; set; }
    public string? Type { get; set; }
    public int ItemId { get; set; }
    public string? Description { get; set; }
}
