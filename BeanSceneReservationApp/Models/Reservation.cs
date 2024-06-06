using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneReservationApp.Models
{
    public partial class Reservation
    {
        public int ReservationId { get; set; }
        public int? SittingId { get; set; }
        public string? GuestName { get; set; } = null!;
        public string? Email { get; set; } = null!;
        public string? Phone { get; set; }
        public DateTime StartTime { get; set; }
        public int NumOfGuests { get; set; }
        public string ReservationSource { get; set; } = null!;
        public string? Notes { get; set; }
        public OrderSource OrderSource { get; set; }
        [Required]
        [Display(Name = "Reservation Status")]
        public ReservationStatus ReservationStatus { get; set; }
        public SittingTime SittingTime { get; set; }
        public AreaName AreaName { get; set; }
        public int? TableId { get; set; }
        public virtual RestaurantTable? Table { get; set; }
    }

    public enum ReservationStatus
    {
        Pending = 0,
        Available = 1,
        Booked = 2,
        Seated = 3,
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

    }
}
