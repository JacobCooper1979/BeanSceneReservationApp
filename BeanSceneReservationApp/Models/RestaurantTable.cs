using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [StringLength(50)]
        public string TableStatus { get; set; } = null!;

        public virtual Area Area { get; set; } = null!;
        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }
}
