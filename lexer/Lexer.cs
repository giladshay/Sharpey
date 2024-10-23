using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Runtime.ConstrainedExecution;
using Sharpey.errors;
using Sharpey.tokens;

namespace Sharpey.lexer {
    public class Lexer(string text)
    {
        private readonly string text = text;
        private int position = 0;
        private static readonly char NULL_CHARACTER = '\0';
        private static readonly Dictionary<char, TokenType> tokenMap = new Dictionary<char, TokenType> {
            {'+', TokenType.Addition},
            {'-', TokenType.Subtraction},
            {'*', TokenType.Multiplication},
            {'/', TokenType.Division},
            {'(', TokenType.LeftParenthesis},
            {')', TokenType.RightParenthesis}
        };

        public List<Token> Tokenize() {
            List<Token> tokens = [];

            while (GetCurrentCharacter() != NULL_CHARACTER) {
                if (char.IsWhiteSpace(GetCurrentCharacter())) {
                    Advance();
                } else if (tokenMap.TryGetValue(GetCurrentCharacter(), out TokenType tokenType)) {
                    tokens.Add(new Token(tokenType));
                    Advance();
                } else if (char.IsDigit(GetCurrentCharacter())) {
                    tokens.Add(TokenizeNumericToken());
                } else {
                    char charcater = GetCurrentCharacter();
                    throw new IllegalCharacterException("'" + charcater + "'");
                }
            }

            return tokens;
        }

        private void Advance() {
            position ++;
        }

        private char GetCurrentCharacter() {
            if (position < text.Length) {
                return text[position];
            } 
            return NULL_CHARACTER;
        }

        private NumericToken TokenizeNumericToken() {
            bool isFloat = false;
            string number = "";
            
            while (GetCurrentCharacter() != NULL_CHARACTER && (char.IsDigit(GetCurrentCharacter()) || GetCurrentCharacter() == '.')) {
                if (GetCurrentCharacter() == '.') {
                    if (isFloat) {
                        break;
                    }
                    isFloat = true;
                }
                number += GetCurrentCharacter();
                Advance();
            }
            return ConvertStringToNumericToken(number);
        }

        private static NumericToken ConvertStringToNumericToken(string number) {
            bool isFloat = IsNumberFloat(number);
            NumericTokenValue numberValue = GetNumberValue(number, isFloat);
            NumericTokenType type = GetNumericTokenType(isFloat);
            return new NumericToken(type, numberValue);
        }

        private static bool IsNumberFloat(string number) => number.Contains('.');
        private static NumericTokenValue GetNumberValue(string number, bool isFloat) =>
            isFloat ? new NumericTokenValue(float.Parse(number)) : new NumericTokenValue(int.Parse(number));
        private static NumericTokenType GetNumericTokenType(bool isFloat) => 
            isFloat ? NumericTokenType.Float : NumericTokenType.Integer;
    }
}