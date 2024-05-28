using System;
using System.Collections.Generic;

namespace BeanSceneReservationApp.Models;

public partial class Reservation
{
    public int ReservationId { get; set; }

    public int? SittingId { get; set; }

    public string GuestName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public DateTime StartTime { get; set; }

    public int Duration { get; set; }

    public int NumOfGuests { get; set; }

    public string ReservationSource { get; set; } = null!;

    public string? Notes { get; set; }

    public string ReservationStatus { get; set; } = null!;

    public int? TableId { get; set; }

    public int? MemberId { get; set; }

    public virtual Member? Member { get; set; }

    public virtual SittingSchedule? Sitting { get; set; }

    public virtual RestaurantTable? Table { get; set; }
}
