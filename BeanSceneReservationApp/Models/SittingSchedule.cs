using System;
using System.Collections.Generic;

namespace BeanSceneReservationApp.Models;

public partial class SittingSchedule
{
    public int SittingId { get; set; }

    public string Stype { get; set; } = null!;

    public DateTime StartDateTime { get; set; }

    public DateTime EndDateTime { get; set; }

    public int Scapacity { get; set; }

    public string? Status { get; set; }

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
