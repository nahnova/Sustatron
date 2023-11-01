namespace Sustatron.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


public class Commute
{
    [Key]
    public int Id { get; set; }
    [ForeignKey("UserId")]
    public int UserId { get; set; }
    public User User { get; set; }
    [ForeignKey("TransportationOptionId")]
    public int TransportationOptionId { get; set; }
    public TransportationOption TransportationOption { get; set; }
    public DateTime Date { get; set; }
    public string StartLocation { get; set; }
    public string EndLocation { get; set; }
    public double Distance { get; set; }
    public double Duration { get; set; }
    public double CarbonEmissions { get; set; }
}
