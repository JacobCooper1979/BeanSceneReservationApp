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
    [NotMapped]
    public string Roll { get; set; }
    [ForeignKey("ApplicationUser")]
    
    public string UserId { get; set; }

    public ApplicationUser User { get; set; }
}