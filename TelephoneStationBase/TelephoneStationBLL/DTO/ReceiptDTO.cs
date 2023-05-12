namespace TelephoneStationBLL.DTO;
public class ReceiptDTO
{
    public int Id {  get; set; }
    public DateTime Date { get; set; }
    public double Price { get; set; }
    public bool IsBought { get; set; }
    public string? Type { get; set; }
    public string? Datails { get; set; }
}
