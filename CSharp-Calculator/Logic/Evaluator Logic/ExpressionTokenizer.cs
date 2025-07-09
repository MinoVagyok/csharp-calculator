using System.ComponentModel.Design;
using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
using System.Security.Cryptography.X509Certificates;
using CSharp_Calculator.Logic.Error_Handling;
using Token = CSharp_Calculator.Logic.Token_Logic.Token;
using TokenType = CSharp_Calculator.Logic.Token_Logic.TokenType;

namespace CSharp_Calculator.Logic;

public class ExpressionTokenizer
{
    public static List<Token> Tokenizer(string expression)
    {
        List<Token> list = new List<Token>();
        string CurrentNumber = "";
        for (int i = 0; i < expression.Length; i++)
        {
            char Current_Char = expression[i];
            if (char.IsDigit(Current_Char) || (Current_Char == '.' && !CurrentNumber.Contains(".")))
            {
                CurrentNumber += Current_Char.ToString();
            }
            else
            {
                if (!string.IsNullOrEmpty(CurrentNumber))
                {
                    var tokenNumber = new Token(TokenType.Number, CurrentNumber);
                    list.Add(tokenNumber);
                    CurrentNumber = "";
                }

                if (Current_Char == '(')
                {
                    list.Add(new Token(TokenType.LeftParenthesis, Current_Char.ToString()));
                }
                else if (Current_Char == ')')
                {
                    list.Add(new Token(TokenType.RightParenthesis, Current_Char.ToString()));
                }
                else if (Current_Char == '+' || Current_Char == '-' || Current_Char == '*' || Current_Char == '/')
                {
                    list.Add(new Token(TokenType.Operator, Current_Char.ToString()));
                }
                else if (Current_Char != ' ')
                {
                    Console.WriteLine("Invalid Token Sequence (Tokenizer 1)" );
                }
            }
        }
        if (!string.IsNullOrEmpty(CurrentNumber) && float.TryParse(CurrentNumber, out _))
        {
            var tokenNumber = new Token(TokenType.Number, CurrentNumber);
            list.Add(tokenNumber);
        }
        return list;
    }
    
}