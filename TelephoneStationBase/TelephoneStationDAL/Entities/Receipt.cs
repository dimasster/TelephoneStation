using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TelephoneStationDAL.Entities;
public class Receipt
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int UserId { get; set; }

    public DateTime Date { get; set; } = DateTime.Now;

    [Required]
    [Column(TypeName = "money")]
    public double Price { get; set; }

    public bool IsBought { get; set; } = false;

    public User? User { get; set; }
}
