namespace Sharpey.tokens {
    public class NumericTokenValue {
        private readonly int integerValue;
        private readonly float floatValue;
        private readonly bool isFloat;
        public NumericTokenValue(int integerValue) {
            this.integerValue = integerValue;
            isFloat = false;
            floatValue = 0f;
        }
        public NumericTokenValue(float floatValue) {
            this.floatValue = floatValue;
            integerValue = 0;
            isFloat = true;
        }
        public new string ToString() => isFloat ? floatValue.ToString() : integerValue.ToString();
    }
}