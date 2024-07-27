using BeanSceneReservationApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

public class Member 
{
    public int MemberId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; } 
    public string Password { get; set; }
    public DateTime RegistrationDate { get; set; }



    [ForeignKey("ApplicationUser")]
    
    public string UserId { get; set; }


    public string Role { get; set; }


    public ApplicationUser User { get; set; }
}
