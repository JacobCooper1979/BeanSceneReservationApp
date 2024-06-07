using BeanSceneReservationApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Member : IUserDetails
{
    public int MemberId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public int Phone { get; set; }
    public string Password { get; set; }
    public DateTime RegistrationDate { get; set; }

    // Add foreign key to ApplicationUser
    [ForeignKey("ApplicationUser")]
    public string UserId { get; set; }

    // Navigation property to ApplicationUser
    public ApplicationUser User { get; set; }
}