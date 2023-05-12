using System.ComponentModel.DataAnnotations;

namespace TelephoneStationDAL.Entities;
public class SavedUser
{
    [Required]
    public int UserId { get; set; }

    [Required]
    public int TargetId { get; set; }

    public User? User { get; set; }

    public User? Target { get; set; }
}
