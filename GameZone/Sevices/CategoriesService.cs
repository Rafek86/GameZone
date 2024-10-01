using GameZone.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace GameZone.Sevices
{
    public class CategoriesService : ICategoriesService
    {
        private readonly ApplicationDbContext _context;
      
        public CategoriesService(ApplicationDbContext context) { 
            _context = context;
        }

        public IEnumerable<SelectListItem> GetSelectList()
        {
          return  _context.Categories.Select(
            c => new SelectListItem
            {
                Text = c.Name,
                Value = c.Id.ToString()
            }).OrderBy(c => c.Text)
            .AsNoTracking()
            .ToList();

        }
    }
}
