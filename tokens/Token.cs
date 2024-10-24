namespace Sharpey.tokens {
    public class Token(TokenType type) {
        private readonly TokenType type = type;

        public TokenType GetTokenType() => type;

        public new virtual string? ToString() => type.ToString();
    }
}