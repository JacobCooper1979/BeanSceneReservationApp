using System.Collections.Generic;
using System.Threading.Tasks;
using BeanSceneReservationApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BeanSceneReservationApp.Services
{
    public class AreaServices : IAreaServices
    {
        private readonly BeanSeanReservationDbContext _context;

        public AreaServices(BeanSeanReservationDbContext context)
        {
            _context = context;
        }

        public async Task<Area> GetAreaByIdAsync(int areaId)
        {
            return await _context.Areas.FindAsync(areaId);
        }

        public async Task<IEnumerable<Area>> GetAllAreasAsync()
        {
            return await _context.Areas.ToListAsync();
        }

        public async Task<Area> CreateAreaAsync(Area area)
        {
            _context.Areas.Add(area);
            await _context.SaveChangesAsync();
            return area;
        }

        public async Task<Area> UpdateAreaAsync(Area area)
        {
            _context.Areas.Update(area);
            await _context.SaveChangesAsync();
            return area;
        }

        public async Task<bool> DeleteAreaAsync(int areaId)
        {
            var area = await _context.Areas.FindAsync(areaId);
            if (area == null)
            {
                return false;
            }

            _context.Areas.Remove(area);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
