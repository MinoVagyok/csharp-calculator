namespace CSharp_Calculator.Logic;

public class Token_Logic
{
    public enum TokenType
    {
        Number,
        Operator,
        Parenthesis
    }

    public class Token
    {
        public TokenType Type { get; set; }
        public string Value { get; set; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }
    }
}