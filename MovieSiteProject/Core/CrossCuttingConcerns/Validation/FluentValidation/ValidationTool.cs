using FluentValidation;

namespace MovieSiteProject.Core.CrossCuttingConcerns.Validation.FluentValidation
{
    public static class ValidationTool
    {
        public static List<string> Validate(IValidator validator, object entity)
        {
            var context = new ValidationContext<object>(entity);
            var result = validator.Validate(context);

            if (!result.IsValid)
            {
                List<string> errors = new List<string>();
                foreach (var error in result.Errors)
                {
                    errors.Add(error.ErrorMessage);
                }

                return errors;
            }

            return null;
        }
    }
}