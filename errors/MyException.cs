namespace Sharpey.errors {
    public class MyException(string errorName, string message) : Exception {
        private readonly string errorName = errorName;
        private readonly string message = message;
    
    public new virtual string? ToString() => string.Format("{0}: {1}", errorName, message);
    }
}