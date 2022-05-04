namespace MovieSiteProject.Core.Exceptions
{
    [Serializable]
    public class ValidationException : Exception
    {
        public List<string> Errors { get; set; }
        public string ErrorMessage { get; set; }
        public ExceptionType ExceptionType { get; } = ExceptionType.ValidationException;

        public ValidationException()
        {
            ErrorMessage = "Doğrulama Hatası";
        }

        public ValidationException(string errorMessage) : base(errorMessage)
        {
            ErrorMessage = errorMessage;
        }

        public ValidationException(List<string> errors, string errorMessage) : base(errorMessage)
        {
            Errors = errors;
            ErrorMessage = errorMessage;
        }

        public ValidationException(Exception inner, List<string> errors, string errorMessage) : base(errorMessage, inner)
        {
            Errors = errors;
            ErrorMessage = errorMessage;
        }

        protected ValidationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
