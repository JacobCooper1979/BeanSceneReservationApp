using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace BeanSceneReservationApp.Models
{
    public partial class RestaurantTable
    {
        [Key]
        public int TableId { get; set; }

        [Required]
        [StringLength(255)]
        public string TableName { get; set; } = null!;

        [ForeignKey("Area")]
        public int AreaId { get; set; }

        public TableStatus TableStatus { get; set; }
        public AreaName AreaName { get; set; }

        public Area? Area { get; set; }
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

    public enum TableStatus
    {
        Pending = 0,
        Cancelled = 1,
        Available = 2,
    }
}
