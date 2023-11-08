using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public int StudentNumber { get; set; }


    public Vehicle? Vehicle { get; set; }
    public ICollection<Vehicle>? Vehicles { get;}
    public int? CommuteId { get; set; }
    public Commute? Commute { get; set; }
}
