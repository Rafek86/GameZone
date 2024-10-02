using System.ComponentModel.DataAnnotations;

namespace GameZone.Attributes
{
    public class MaxSizeAttribute : ValidationAttribute
    {

        private readonly int _maxSize;

        public MaxSizeAttribute(int maxSize) 
        {
        _maxSize = maxSize;
        }

        protected override ValidationResult? IsValid
           (object? value, ValidationContext validationContext)
        {
            var file = value as IFormFile;

            if (file is not null)
            {
                if (file.Length > _maxSize) {
                    return new ValidationResult(errorMessage: $"Max size is {_maxSize} bytes ");
                }
            }
            return ValidationResult.Success;
        }
    }
}
