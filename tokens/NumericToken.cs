using System.Xml.Schema;

namespace Sharpey.tokens {
    public class NumericToken(NumericTokenType numericType, NumericTokenValue value) : Token(TokenType.Value)
    {
        private readonly NumericTokenValue value = value;
        private readonly NumericTokenType numericType = numericType; 

        public NumericTokenValue GetTokenValue() => value;

        public override string ToString => numericType.ToString() + value.ToString;
    }
}