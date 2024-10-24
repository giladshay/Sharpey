using System.Runtime.InteropServices.Marshalling;
using Sharpey.lexer;

namespace Sharpey.errors {
    public class IllegalCharacterException(
        string message,
        Position start,
        Position end) : MyException("Invalid Character", message, start, end) {
        
    }
}