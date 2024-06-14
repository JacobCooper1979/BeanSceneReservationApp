
using Microsoft.AspNetCore.Identity;

namespace BeanSceneReservationApp.Models
{
    public class ApplicationUser : IdentityUser, IUserDetails
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime RegistrationDate { get; set; } = DateTime.Now; 
        public int Phone { get; set; }
    }
}
