using System.Globalization;
using CSharp_Calculator.Logic.Error_Handling;
using Microsoft.VisualBasic.CompilerServices;
using Token = CSharp_Calculator.Logic.Token_Logic.Token;
using TokenType = CSharp_Calculator.Logic.Token_Logic.TokenType;

namespace CSharp_Calculator.Logic;

public class ExpressionEvaluator
{
    public static float Evaluate(List<Token> tokens)
    {
        if (ErrorHandler.IsValidTokenSequence(tokens))
        {
            float currentResult = float.Parse(tokens[0].Value, CultureInfo.InvariantCulture);
            int index = 1;
            while (index  < tokens.Count)
            {
                Token operatorToken = tokens[index];
                Token nextToken = tokens[index+1];
                if (tokens[index % 2].Type != TokenType.Operator || nextToken.Type != TokenType.Number)
                {
                    Console.WriteLine("Invalid token sequence.");
                    return 0;
                }
                float nextNumber = float.Parse(nextToken.Value);
                switch (operatorToken.Value)
                {
                    case "+":
                        currentResult += nextNumber;
                        break;
                    case "-":
                        currentResult -= nextNumber;
                        break;
                    case "/":
                        if (ErrorHandler.IsSafeToDivide(nextNumber))
                        {
                            currentResult /= nextNumber;
                        }
                        else
                        {
                           Console.WriteLine("Cannot divide by zero.");
                           return 0;
                        }
                        break;
                    case "*":
                        currentResult *= nextNumber;
                        break;
                    default:
                        Console.WriteLine("Error: Invalid operator token.");
                        return 0;
                }
                index += 2;
            }
            return currentResult;
        }
        Console.WriteLine("Error: Invalid token sequence.");
        return 0;
    }
}