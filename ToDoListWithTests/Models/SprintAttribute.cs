using System.ComponentModel.DataAnnotations;

namespace ToDoList.Models
{
    public class SprintAttribute: ValidationAttribute
    {
        protected override ValidationResult IsValid(object? value, ValidationContext cxt)
        {
            if (value is int)
            {
                int sprint = (int)value;
                for (int i = 0;i< 30;i++)
                {
                    if(sprint < i)
                    {
                        string msg = base.ErrorMessage ?? "This is not a valid sprint number";
                        return new ValidationResult(msg);
                    }
                    else if(sprint == i)
                    {
                        string msg = base.ErrorMessage ?? "This sprint number already exists";
                        return new ValidationResult(msg);
                    }
                    else if(sprint > i)
                    {
                        break;
                    }
                }

            }
            return ValidationResult.Success;
        }
    }
}
