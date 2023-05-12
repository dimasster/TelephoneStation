using System.ComponentModel.DataAnnotations;

namespace TelephoneStationDAL.Entities;
public class CallReceipt: Receipt
{
    [Required]
    public int CallId { get; set; }

    public Call? Call { get; set; }
}
