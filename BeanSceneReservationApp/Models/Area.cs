using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;

namespace BeanSceneReservationApp.Models
{
    public partial class Area
    {
        public int AreaId { get; set; }
        public AreaName AreaName { get; set; }
        public int Capacity { get; set; } = 40;
        [NotMapped]
        public IFormFile? ImageFile { get; set; }
        public string? Image { get; set; }

        public virtual ICollection<RestaurantTable> RestaurantTables { get; set; } = new List<RestaurantTable>();
    }

    public enum AreaName
    {
        Main,
        Outdoor,
        Balcony
    }
}
