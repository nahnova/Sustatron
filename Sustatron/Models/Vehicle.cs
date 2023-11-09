using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models
{
    public class Vehicle
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public required string VehicleName { get; set; }
        public required string LicencePlate { get; set; }
        public int MaxEmission { get; set; }
        public int CurrentEmission { get; set; }

        public ICollection<Commute>? Commutes { get; set; }
        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
