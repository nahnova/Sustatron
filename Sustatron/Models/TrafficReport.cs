using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models;

public class TrafficReport
{
    [Key]
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public string TrafficConditions { get; set; }
    public string Source { get; set; }
}
