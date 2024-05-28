/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneReservationApp.Models;

public partial class RestaurantTable
{
    public int TableId { get; set; }

    public string TableName { get; set; } = null!;
    [ForeignKey("AreaID")]
    public int AreaId { get; set; }

    public string? TableStatus { get; set; }

    public virtual Area Area { get; set; } = null!;

    public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
}
*/

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneReservationApp.Models
{
    public partial class RestaurantTable
    {
        public int TableId { get; set; }
        public string TableName { get; set; } = null!;
        public int AreaId { get; set; }
        public string? TableStatus { get; set; }
        public virtual Area Area { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
