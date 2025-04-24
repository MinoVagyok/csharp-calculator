using System.Globalization;
using System.Runtime.InteropServices.JavaScript;
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
            else if (Current_Char == '-' || Current_Char == '+' || Current_Char == '*' || Current_Char == '/')
            {
                
                if (string.IsNullOrEmpty(CurrentNumber) || !float.TryParse(CurrentNumber, out _))
                {
                    Console.WriteLine("Invalid token sequence");
                    return null;
                }
            
                var tokenNumber = new Token(TokenType.Number, CurrentNumber); 
                list.Add(tokenNumber);
                
                var tokenOperator = new Token(TokenType.Operator, Current_Char.ToString());
                list.Add(tokenOperator);
        
                CurrentNumber = "";

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