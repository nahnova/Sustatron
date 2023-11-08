namespace Sustatron.Models
{
    public class Vehicle
    {
        public int Id { get; set; }
        public required string VehicleName { get; set; }
        public required string LicencePlate { get; set; }
        public int MaxEmission { get; set; }
        public int CurrentEmission { get; set; }


        public int UserId { get; set; }
        public required User User { get; set; }
        public int CommuteId { get; set; }
        public Commute? Commute { get; set; }
    }
}
