using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Sevices
{
    public interface IDevicesService
    {
        IEnumerable<SelectListItem> GetDevices();
    }
}
