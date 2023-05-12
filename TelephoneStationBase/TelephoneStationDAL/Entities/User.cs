using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelephoneStationDAL.Enums;

namespace TelephoneStationDAL.Entities;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    [StringLength(20)]
    public string? Name { get; set; }

    [StringLength(20)]
    public string? LastName { get; set; }

    [Required]
    [StringLength(20)]
    public int PhoneNumber { get; set; }

    public UserRole Role { get; set; } = UserRole.Unknown;

    public bool IsBanned { get; set; } = false;

    [Required]
    public double Ballance { get; set; }

    public Account? Account { get; set; }

    public List<Call> Calls { get; set; } = new List<Call>();

    public List<Call> Callers { get; set; } = new List<Call>();

    public List<Receipt> Receipts { get; set; } = new List<Receipt>();

    public List<SavedUser> Contacts { get; set; } = new List<SavedUser>();

    public List<SavedUser> Contacters { get; set; } = new List<SavedUser>();

    public Subscription? Subscription { get; set; }
}
