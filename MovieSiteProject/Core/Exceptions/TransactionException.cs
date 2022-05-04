namespace MovieSiteProject.Core.Exceptions
{
    [Serializable]
    public class TransactionException : Exception
    {
        public string Error { get; set; }
        public ExceptionType ExceptionType { get; } = ExceptionType.TransactionException;

        public TransactionException()
        {
            Error = "Transaction Error";
        }

        public TransactionException(string error) : base(error)
        {
            Error = error;
        }

        public TransactionException(string error, Exception inner) : base(error, inner)
        {
            Error = error;
        }

        protected TransactionException(
          System.Runtime.Serialization.SerializationInfo info,
          System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
