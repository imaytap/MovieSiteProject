namespace MovieSiteProject.Core.Utilities.Results
{
    public class BusinessRuleResult : Result
    {
        public List<IResult> Errors { get; set; }
        public IResult FirstError { get; set; }

        public BusinessRuleResult(List<IResult> errors, bool success) : base(success)
        {
            Errors = errors;
            FirstError = errors.FirstOrDefault();
        }

        public BusinessRuleResult(List<IResult> errors, bool success, string message) : base(success, message)
        {
            Errors = errors;
            FirstError = errors.FirstOrDefault();
        }
    }
}
