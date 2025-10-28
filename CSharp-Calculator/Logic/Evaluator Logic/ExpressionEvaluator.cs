using Token = CSharp_Calculator.Logic.Token_Logic.Token;
using TokenType = CSharp_Calculator.Logic.Token_Logic.TokenType;
using System.Globalization;

namespace CSharp_Calculator.Logic;

public class ExpressionEvaluator
{
    
    public static float EvaluatePostFix(List<Token> postfixTokens)
    {
        if (postfixTokens == null || postfixTokens.Count == 0)
            throw new ArgumentException("Postfix token list is empty.", nameof(postfixTokens));
        
        Stack<float> operandusStack = new Stack<float>();
        foreach (Token token in postfixTokens)
        {
            if (token.Type == TokenType.Number)
            {
                if (!float.TryParse(token.Value, NumberStyles.Float, CultureInfo.InvariantCulture, out var value))
                    throw new FormatException($"Invalid number token: {token.Value}");
                operandusStack.Push(value);
            }

            else if (token.Type == TokenType.Operator)
            {
                if (operandusStack.Count < 2)
                {
                    throw new InvalidOperationException("Too few operands in stack.");
                }
                
                var operandRight = operandusStack.Pop();
                var operandLeft = operandusStack.Pop();
                float solution;

                switch (token.Value)
                {
                    case "+": solution = operandLeft + operandRight; break;
                    case "-": solution = operandLeft - operandRight; break;
                    case "*": solution = operandLeft * operandRight; break;
                    case "/":         
                        if (operandRight == 0f)
                            throw new DivideByZeroException("Division by zero is not allowed.");
                        solution = operandLeft / operandRight;
                        break;
                    default:
                        throw new NotSupportedException($"Unsupported operator '{token.Value}'.");
                }
                operandusStack.Push(solution);
            }
        }
        
        if (operandusStack.Count != 1)
        {
            throw new InvalidOperationException("Invalid postfix expression.");
        }
        return operandusStack.Pop();
        
    }
}