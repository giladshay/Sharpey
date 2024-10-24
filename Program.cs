// See https://aka.ms/new-console-template for more information
using Sharpey.errors;
using Sharpey.lexer;
using Sharpey.tokens;

const string SHELL_PROMPT = ">> ";

static List<Token> run(string text) {
    Lexer lexer = new Lexer(text);
    List<Token> tokens = lexer.Tokenize();
    return tokens;
}

static void printArray(List<Token> tokens) {
    Console.Write('[');
    foreach (Token token in tokens) {
        Console.Write(token.ToString() + ", ");
    }
    Console.WriteLine(']'); 
}

while (true) {
    Console.Write(SHELL_PROMPT);
    string? text = Console.ReadLine();
    if (text == null) {
        continue;
    }
    try {
        List<Token> tokens = run(text);
        printArray(tokens);
    } catch (MyException e) {
        Console.WriteLine(e.Message);
    }
}