/*using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeanSceneReservationApp.Models
{
    public partial class SittingSchedule
    {
        public int SittingId { get; set; }
        
        public int AreaId { get; set; }

        // Navigation property for Area
        public virtual Area Area { get; set; } // Assuming a Sitting is associated with one Area

        public virtual ICollection<Reservation> Reservations { get; set; } = new List<Reservation>();
    }

    

}


*/