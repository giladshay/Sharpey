namespace Sharpey.errors {
    public class IllegalCharacterException(string message) : MyException("Invalid Character", message) {
        
    }
}