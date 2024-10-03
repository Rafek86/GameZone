using GameZone.Attributes;
using GameZone.Settings;

namespace GameZone.ViewModels
{
    public class EditGameFormVM :GameFormVM
    {
        public int Id { get; set; }

        public string? CurrentCover { get; set; }

        [AllowExtentions(FileSettings.AllowExtentioins)
        , MaxSize(FileSettings.MaxFileSizeInBytes)]
        public IFormFile? Cover { get; set; } = default!;
    }
}
