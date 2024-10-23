namespace Sharpey.errors {
    public class MyException(string errorName, string message) : Exception {
        private readonly string errorName = errorName;
        private readonly string message = message;
    }
}