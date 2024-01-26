namespace LibraryApp.Api.Settings
{
    public class Envelope<T>
    {
        public T? Result { get; }
        public string ErrorMessage { get; }
        public DateTime TimeGenerated { get; }
        public bool IsSuccess { get; }

        protected internal Envelope(T result, string errorMessage, bool isSuccess)
        {
            Result = result;
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
            IsSuccess = isSuccess;
        }

        public Envelope(string errorMessage, bool isSuccess)
        {
            ErrorMessage = errorMessage;
            TimeGenerated = DateTime.UtcNow;
            IsSuccess = isSuccess;
        }
    }

    public sealed class Envelope : Envelope<string>
    {
        private Envelope(string errorMessage, bool isSuccess)
            : base(errorMessage, isSuccess)
        {
        }

        public static Envelope<T> BaseResult<T>(T result)
        {
            return new Envelope<T>(result, string.Empty, true);
        }

        public static Envelope BaseResult()
        {
            return new Envelope(string.Empty, true);
        }

        public static Envelope BaseError(string errorMessage)
        {
            return new Envelope(errorMessage, false);
        }

        public static Envelope BaseError()
        {
            return new Envelope(string.Empty, false);
        }
    }
}
