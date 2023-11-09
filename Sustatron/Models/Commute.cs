using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models
{
    public class Commute
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int KmDistance { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User? User { get; set; }
    }
}
