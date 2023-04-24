using TelephoneStationDAL.Enums;

namespace TelephoneStationBLL.DTO;
public class UserDTO
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? LastName { get; set; }
    public int PhoneNumber { get; set; }

    //todo: separate it to auth service
    public UserRole Role { get; set; }

    //todo: separate it to admin service
    public bool IsBanned { get; set; }

    //todo: separate it to ballance service
    public double Ballance { get; set; }
}
