using MovieSiteProject.Core.Utilities.Results;
using IResult = MovieSiteProject.Core.Utilities.Results.IResult;

namespace MovieSiteProject.Core.Services
{
    public static class BusinessRules
    {
        public static BusinessRuleResult Run(params IResult[] logics)
        {
            var hasError = false;
            var errors = new List<IResult>();

            IResult result = new SuccessResult();

            var index = 0;
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    hasError = true;
                    errors.Add(logic);
                    if (index == 0)
                        result = logic;

                    index++;
                }
            }

            if (hasError)
                return new BusinessRuleResult(errors, false, result.Message);

            return new BusinessRuleResult(errors, true, "İşlem Başarılı");
        }
    }
}
