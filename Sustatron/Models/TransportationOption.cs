using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models;

public class TransportationOption
{
    [Key]
    public int Id { get; set; }
    public string optionName { get; set; }
    public string description { get; set; }
    public string icon { get; set; }
    public ICollection<Commute> Commutes { get; set; }
}