using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneReservationApp.Models;

public partial class Area
{
    public int AreaId { get; set; }

    public string AreaName { get; set; } = null!;

    public int Capacity { get; set; }

    [NotMapped]
    public IFormFile? ImageFile { get; set; }
    public string? Image { get; set; }
    public virtual ICollection<RestaurantTable> RestaurantTables { get; set; } = new List<RestaurantTable>();
}
