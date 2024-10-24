using System.Xml.Schema;

namespace Sharpey.tokens {
    public class NumericToken(NumericTokenType type, NumericTokenValue value) : Token(TokenType.Value)
    {
        private readonly NumericTokenValue value = value;
        private readonly NumericTokenType type = type; 

        public NumericTokenValue GetTokenValue() => value;

        public override string ToString() => string.Format("{0}:{1}", type.ToString(), value.ToString());
    }
}