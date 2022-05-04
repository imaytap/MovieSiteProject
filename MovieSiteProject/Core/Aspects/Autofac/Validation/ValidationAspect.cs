using Castle.DynamicProxy;
using FluentValidation;
using MovieSiteProject.Core.CrossCuttingConcerns.Validation.FluentValidation;
using MovieSiteProject.Core.Utilities.Interceptors;

namespace MovieSiteProject.Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private readonly Type _validatorType;
        private List<string> _errors;

        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
                throw new Exception("Is not a validation class");

            _validatorType = validatorType;
        }

        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];

            var notNullEntities = invocation.Arguments.Where(t => t != null);
            var entities = notNullEntities.Where(t => t.GetType() == entityType);
            foreach (var entity in entities) _errors = ValidationTool.Validate(validator, entity);

            if (_errors != null)
            {
                var validationErrors = new List<string>();

                foreach (var error in _errors) validationErrors.Add(error);

                throw new Exceptions.ValidationException(validationErrors, "Validation Error");
            }
        }
    }
}