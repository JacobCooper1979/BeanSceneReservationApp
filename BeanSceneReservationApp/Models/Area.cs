using System;
using System.Collections.Generic;

namespace BeanSceneReservationApp.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public int Capacity { get; set; }

    public virtual ICollection<RestaurantTable> RestaurantTables { get; set; } = new List<RestaurantTable>();
}
