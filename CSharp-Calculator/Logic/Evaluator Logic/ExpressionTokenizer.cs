using Token = CSharp_Calculator.Logic.Token_Logic.Token;
using TokenType = CSharp_Calculator.Logic.Token_Logic.TokenType;
using System.Globalization;

namespace CSharp_Calculator.Logic;

public class ExpressionTokenizer
{
    public static List<Token> Tokenizer(string expression)
    {
        if (string.IsNullOrWhiteSpace(expression))
            throw new ArgumentException("Expression is empty.", nameof(expression));
        expression = expression.Trim();
        
        List<Token> list = new List<Token>();
        string CurrentNumber = "";
        for (int i = 0; i < expression.Length; i++)
        {
            char Current_Char = expression[i];
            if (char.IsDigit(Current_Char) || (Current_Char == '.' && !CurrentNumber.Contains(".")))
            {
                CurrentNumber += Current_Char;
            }
            else
            {
                if (!string.IsNullOrEmpty(CurrentNumber))
                {
                    if (!float.TryParse(CurrentNumber, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
                        throw new FormatException($"Invalid number format: {CurrentNumber}");
                    
                    list.Add(new Token(TokenType.Number, CurrentNumber));
                    CurrentNumber = "";
                }
                
                if (char.IsWhiteSpace(Current_Char))
                    continue;
                
                if ((Current_Char == '-' || Current_Char == '+') && IsUnaryPosition(expression, i))
                {
                    CurrentNumber += Current_Char.ToString();
                    continue;
                }

                if (Current_Char == '(')
                {
                    list.Add(new Token(TokenType.LeftParenthesis, Current_Char.ToString()));
                    continue;
                }
                if (Current_Char == ')')
                {
                    list.Add(new Token(TokenType.RightParenthesis, Current_Char.ToString()));
                    continue;
                }
                if (Current_Char == '+' || Current_Char == '-' || Current_Char == '*' || Current_Char == '/')
                {
                    list.Add(new Token(TokenType.Operator, Current_Char.ToString()));
                    continue;
                }
                
                throw new FormatException($"Invalid token: '{Current_Char}' at position {i}"); 

            }
        }
        if (!string.IsNullOrEmpty(CurrentNumber))
        {
            if (!float.TryParse(CurrentNumber, NumberStyles.Float, CultureInfo.InvariantCulture, out _))
                throw new FormatException($"Invalid number at end: {CurrentNumber}");
            
            list.Add(new Token(TokenType.Number, CurrentNumber));
        }
        return list;
    }
    private static bool IsUnaryPosition(string s, int i)
    {
        if (i == 0) return true;

        // find previous non-whitespace char
        int j = i - 1;
        while (j >= 0 && char.IsWhiteSpace(s[j])) j--;

        if (j < 0) return true; // all whitespace before => unary

        char prev = s[j];
        return prev == '(' || prev == '+' || prev == '-' || prev == '*' || prev == '/';
    }
    
}