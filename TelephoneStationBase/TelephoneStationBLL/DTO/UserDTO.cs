namespace TelephoneStationBLL.DTO;
public class UserDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int PhoneNumber { get; set; }
    public bool IsBanned { get; set; }
}
