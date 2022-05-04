namespace MovieSiteProject.Core.Exceptions
{
    [Serializable]
    public class AuthorizationException : Exception
    {
        public string Error { get; set; }
        public ExceptionType ExceptionType { get; } = ExceptionType.AuthorizationException;

        public AuthorizationException() : base("Yetkiniz Yok")
        {
            Error = "Yetkiniz Yok";
        }

        public AuthorizationException(string error) : base(error)
        {
            Error = error;
        }

        public AuthorizationException(string error, Exception inner) : base(error, inner)
        {
            Error = error;
        }

        protected AuthorizationException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
