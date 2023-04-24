using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelephoneStationDAL.Entities;
public class Account
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    [Required]
    [StringLength(20)]
    public string? Login { get; set; }

    [Required]
    [PasswordPropertyText]
    [StringLength(20)]
    public string? Password { get; set; }

    public User? User { get; set; }
}
