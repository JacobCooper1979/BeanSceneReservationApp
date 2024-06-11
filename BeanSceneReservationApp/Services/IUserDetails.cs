namespace BeanSceneReservationApp.Models
{
    public interface IUserDetails
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        DateTime RegistrationDate { get; set; }
    }
}
