using System.Collections.Generic;
using System.Threading.Tasks;
using BeanSceneReservationApp.Models;

namespace BeanSceneReservationApp.Services
{
    public interface IAreaServices
    {
        Task<Area> GetAreaByIdAsync(int areaId);
        Task<IEnumerable<Area>> GetAllAreasAsync();
        Task<Area> CreateAreaAsync(Area area);
        Task<Area> UpdateAreaAsync(Area area);
        Task<bool> DeleteAreaAsync(int areaId);
    }
}
