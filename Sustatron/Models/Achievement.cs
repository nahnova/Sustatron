using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models
{
    public class Achievement
    {
        [Key]
        public int Id { get; set; }
        public string AchievementName { get; set; }
        public string Description { get; set; }
        public string Criteria { get; set; }

        // Add a foreign key to relate achievements to users
        [ForeignKey("UserId")]
        public int UserId { get; set; }
        public User User { get; set; }
    }
}