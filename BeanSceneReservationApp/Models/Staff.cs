using System;
using System.Collections.Generic;

namespace BeanSceneReservationApp.Models;

public partial class Staff
{
    public int StaffId { get; set; }

    public string StaffType { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? Phone { get; set; }

    public string Password { get; set; } = null!;
}
