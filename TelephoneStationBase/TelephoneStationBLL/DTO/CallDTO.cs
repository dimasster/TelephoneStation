using TelephoneStationDAL.Enums;

namespace TelephoneStationBLL.DTO;
public class CallDTO
{
    public int Id { get; set; }
    public UserDTO? Caller { get; set; }
    public UserDTO? Target { get; set; }
    public DateTime CallStartDate { get; set; }
    public int CallTime { get; set; }
    public CallStatus Status { get; set; }
}
