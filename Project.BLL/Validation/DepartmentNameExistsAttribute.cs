
using System.ComponentModel.DataAnnotations;

namespace Project.BLL.Validation
{
    public class DepartmentNameExistsAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext validationContext)
        {
            var dbContext = (ApplicationDbContext?)validationContext.GetService(typeof(ApplicationDbContext));
            if (dbContext.Departments.Any(dep => dep.Department_Name == value.ToString()))
            {
                return new ValidationResult("");
            }
            return ValidationResult.Success;
        }

    }
}

