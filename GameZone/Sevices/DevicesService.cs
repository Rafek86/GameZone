using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Sevices
{
    public class DevicesService : IDevicesService
    {
        private readonly ApplicationDbContext _context; 

        public DevicesService(ApplicationDbContext context) {
        _context = context;
        }

        public IEnumerable<SelectListItem> GetDevices()
        {
            return _context.Devices.Select(
                x => new SelectListItem
                {
                   Text = x.Name,
                   Value= x.Id.ToString()
                }).OrderBy(d=>d.Text)
                .AsNoTracking()
                .ToList();
        }
    }
}
