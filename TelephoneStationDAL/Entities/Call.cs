using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TelephoneStationDAL.Enums;

namespace TelephoneStationDAL.Entities;
public class Call
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required]
    public int CallerId { get; set; }

    [Required]
    public int TargetId { get; set; }

    public DateTime CallStartDate { get; set; } = DateTime.Now;

    public int CallTime { get; set; } = 0;

    public CallStatus Status { get; set; } = CallStatus.Started;

    public User? Caller { get; set; }

    public User? Target { get; set; }

    public CallReceipt? Receipt { get; set; }
}
