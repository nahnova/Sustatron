namespace Sustatron.Models
{
    public class Commute
    {
        public int Id { get; set; }
        public int KmDistance { get; set; }
        public DateTime Date { get; set; }


        public Vehicle? Vehicle { get; set; }
        public User? User { get; set; }
    }
}
