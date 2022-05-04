using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using MovieSiteProject.Core.CrossCuttingConcerns.Validation.FluentValidation;

namespace MovieSiteProject.Core.Aspects.System.Validation
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ControllerValidationAspectAttribute : Attribute, IActionFilter
    {
        private readonly Type _validatorType;
        private List<string> _errors;

        public ControllerValidationAspectAttribute(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception("Is not a validation class");

            _validatorType = validatorType;
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            foreach (var item in context.ActionArguments)
            {
                if (item.Value != null && item.Value.GetType() == entityType)
                    _errors = ValidationTool.Validate(validator, item.Value);
            }

            if (_errors != null)
            {
                var validationErrors = new List<string>();

                foreach (var error in _errors) validationErrors.Add(error);

                throw new Exceptions.ValidationException(validationErrors, "Validation Error");
            }
        }

        public void OnActionExecuted(ActionExecutedContext context)
        {
        }
    }
}
