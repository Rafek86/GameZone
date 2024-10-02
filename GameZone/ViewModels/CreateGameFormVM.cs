using GameZone.Attributes;
using GameZone.Settings;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace GameZone.ViewModels
{
    public class CreateGameFormVM
    {
        [MaxLength(250)]
        public string Name { get; set; } = string.Empty;

        [MaxLength(500)]
        public string Description { get; set; } = string.Empty;

        [Display(Name ="Category")]
        public int CategoryId { get; set; } 

        public IEnumerable<SelectListItem> categories { get; set; } = Enumerable.Empty<SelectListItem>();

        [Display(Name= "Supported Devices")]
        public List<int> SelectedDevices { get; set; } =default;

        public IEnumerable<SelectListItem> Devices { get; set; } = Enumerable.Empty<SelectListItem>();

        //Validate Extention and Size
        [AllowExtentions(FileSettings.AllowExtentioins)
            ,MaxSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile Cover { get; set; } = default!;
    }
}
