using System.Globalization;
using System.Windows.Controls;

namespace RecipesManager.Helpers.Validation
{
    public class CategoryNameRule : ValidationRule
    {
        public CategoryNameRule()
        {

        }

        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            string name = value as string;

            if (string.IsNullOrEmpty(name) || string.IsNullOrWhiteSpace(name))
            {
                return new ValidationResult(false, $"Please enter a valid category name");
            }

            return ValidationResult.ValidResult;
        }
    }
}
