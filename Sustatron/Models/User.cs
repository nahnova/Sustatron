using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sustatron.Models;

public class User
{
    [Key]
    public int Id { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Role { get; set; }
    public string ProfilePicture { get; set; }
    public string ContactInformation { get; set; }
    public string CommutingPreferences { get; set; }
    
    
    public ICollection<Commute> Commutes { get; set; }
    
    // Navigation property to related achievements
    public List<Achievement>? Achievements { get; set; }
}
