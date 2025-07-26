using System.Globalization;
using CSharp_Calculator.Logic.Error_Handling;
using Microsoft.VisualBasic.CompilerServices;
using Token = CSharp_Calculator.Logic.Token_Logic.Token;
using TokenType = CSharp_Calculator.Logic.Token_Logic.TokenType;

namespace CSharp_Calculator.Logic;

public class ExpressionEvaluator
{
    
// Legacy method from the infix-based evaluation phase.
// This method is no longer used.
// Current flow: input → Tokenizer → Shunting Yard → EvaluatePostFix,
// and all validation is now handled within those steps.
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
                    Console.WriteLine("Invalid token sequence. (Evaluator 1)");
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
        Console.WriteLine("Error: Invalid token sequence. (Evaluator 2)");
        return 0;
    }

    public static float EvaluatePostFix(List<Token> postfixTokens)
    {
        float solution = 0;
        Stack<float> operandusStack = new Stack<float>();
        foreach (Token token in postfixTokens)
        {
            if (token.Type == TokenType.Number)
            {
                float.TryParse(token.Value, out float operandus);
                operandusStack.Push(operandus);
            }

            if (token.Type == TokenType.Operator)
            {
                if (operandusStack.Count < 2)
                {
                    Console.WriteLine("Error: Too few operandus in stack.(EvaluatePostFix)");
                    return -1;
                }
                
                var operandRight = operandusStack.Pop();
                var operandLeft = operandusStack.Pop();

                if (token.Value == "+")
                {
                    solution = operandLeft + operandRight;
                }

                if (token.Value == "-")
                {
                    solution = operandLeft - operandRight;
                }

                if (token.Value == "*")
                {
                    solution = operandLeft * operandRight;
                }

                if (token.Value == "/")
                {
                    if (operandRight == 0)
                    {
                        Console.WriteLine("Error: Cannot divide by zero.(EvaluatePostFix)");
                        return -1;
                    }
                    solution = operandLeft / operandRight;
                }
                
                operandusStack.Push(solution);

            }
            
        }
        
        if (operandusStack.Count != 1)
        {
            Console.WriteLine("Error: Invalid Posfix expression. (EvaluatePostFix)");
            return -1;
        }
        return operandusStack.Pop();
        
    }
}