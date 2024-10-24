using Sharpey.lexer;

namespace Sharpey.errors {
    public class MyException(
        string errorName, 
        string message, 
        Position start, 
        Position end) : Exception {
        private readonly string errorName = errorName;
        private readonly string message = message;
        private readonly Position start = start;
        private readonly Position end = end;
    
    public new virtual string? ToString() => string.Format(
            "{0}: {1}\nFile {2}, line {3}", errorName, message, start.Filename, start.LineNumber + 1
        );
    }
}