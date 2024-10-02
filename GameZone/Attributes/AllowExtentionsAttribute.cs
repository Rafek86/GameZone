using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
    public class AllowExtentionsAttribute : ValidationAttribute
    {
       private readonly string _allowExtentions;

        public AllowExtentionsAttribute
            (string allowExtentions)
        { 
        _allowExtentions = allowExtentions; 
        }

        protected override ValidationResult? IsValid
            (object? value, ValidationContext validationContext)
        {
          var file =value as IFormFile;

            if (file is not null) {
                var extentions = Path.GetExtension(file.FileName);

                var isAllowed = _allowExtentions.Split(",").Contains(extentions,StringComparer.OrdinalIgnoreCase);
                if (!isAllowed) {
                    return new ValidationResult(errorMessage: $"Only {_allowExtentions} are allowed!");
                }
            }
            return ValidationResult.Success;
        }
    }
}
