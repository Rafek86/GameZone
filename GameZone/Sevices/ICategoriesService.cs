using Microsoft.AspNetCore.Mvc.Rendering;

namespace GameZone.Sevices
{
    public interface ICategoriesService
    {
        IEnumerable<SelectListItem> GetSelectList();
    }
}
