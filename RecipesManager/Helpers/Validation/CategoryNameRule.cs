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
                return new ValidationResult(false, "Please enter a valid category name");
            }

            if (name.Length > 200)
            {
                return new ValidationResult(false, "Category name should be up to 200 characters");
            }

            return ValidationResult.ValidResult;
        }
    }
}
