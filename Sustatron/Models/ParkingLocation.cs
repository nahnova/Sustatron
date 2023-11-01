using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models;

public class ParkingLocation
{
    [Key]
    public int Id { get; set; }
    public string locationName { get; set; }
    public string description { get; set; }
    public int capacity { get; set; }
    public int latitude { get; set; }
    public int longitude { get; set; }
}