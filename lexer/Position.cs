namespace Sharpey.lexer {
    public class Position(int index, int lineNumber, int columnNumber, string filename)
    {
        private int index = index;
        private int lineNumber = lineNumber;
        private int columnNumber = columnNumber;
        private readonly string filename = filename;

        public void Advance(char character) {
            index ++;
            columnNumber ++;
            if (character == '\n') {
                lineNumber ++;
                columnNumber = 0;
            }
        }

        public Position Clone() {
            return new Position(index, lineNumber, columnNumber, filename);
        }

        public int Index => index;
        public int LineNumber => lineNumber;
        public int ColumnNumber => columnNumber;
        public string? Filename => filename;
    }
}
