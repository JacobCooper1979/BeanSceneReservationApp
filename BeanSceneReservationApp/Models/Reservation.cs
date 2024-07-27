using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneReservationApp.Models
{
    public partial class Reservation
    {
        [Key]
        public int ReservationId { get; set; }

        [Required(ErrorMessage = "Guest Name is not required")]
        [StringLength(100, ErrorMessage = "Guest Name cannot be longer than 100 characters please enter a nickname if your name is longer than 100 characters")]
        [Display(Name = "Guest Name")]
        public string? GuestName { get; set; } = null!;

        [Required(ErrorMessage = "Email Address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        public string Email { get; set; } = null!;

        [Phone(ErrorMessage = "Invalid Phone Number")]
        [Display(Name = "Phone Number")]
        public string? Phone { get; set; }

        [Required(ErrorMessage = "Start Time is required")]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Number of Guests is required")]
        [Range(1, 20, ErrorMessage = "Number of Guests must be between 1 and 20")]
        [Display(Name = "Number of Guests")]
        public int NumOfGuests { get; set; }

        [StringLength(500, ErrorMessage = "Additional Notes cannot be longer than 500 characters")]
        public string? Notes { get; set; }

        [Required(ErrorMessage = "Order Source is required")]
        public OrderSource OrderSource { get; set; }

        [Required(ErrorMessage = "Reservation Status is required")]
        [Display(Name = "Reservation Status")]
        public ReservationStatus ReservationStatus { get; set; }

        [Required(ErrorMessage = "Sitting Time is required")]
        [Display(Name = "Sitting Time")]
        public SittingTime SittingTime { get; set; }

        [Required(ErrorMessage = "Area Name is required")]
        [Display(Name = "Area Name")]
        public AreaName AreaName { get; set; }

        [ForeignKey("RestaurantTable")]
        [Display(Name = "Table")]
        public int? TableId { get; set; }

        public virtual RestaurantTable? Table { get; set; }
    }

    public enum ReservationStatus
    {
        Pending = 0,
        Available = 1,
        Booked = 2,
        Seated = 3,
        Completed = 4,
    }

    public enum SittingTime
    {
        Breakfast = 0,
        Lunch = 1,
        Dinner = 2
    }

    public enum OrderSource 
    {
        InPerson = 0,
        WalkIn = 1,
        Online = 2,
        Phone = 3,
        MobileApp = 4,
        Email = 5,

    }
}
