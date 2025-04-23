using CSharp_Calculator.Logic.Error_Handling;

namespace CSharp_Calculator.Logic;

public class ExpressionEvaluator
{
    public static float Evaluate(List<string> tokens)
    {
        if (ErrorHandler.IsValidTokenSequence(tokens))
        {
            var current_result = float.Parse(tokens[0]);
            int index = 1;
            while (index < tokens.Count)
            {
                string operator_token = tokens[index];
                float next_number = float.Parse(tokens[index + 1]);

                if (operator_token == "+")
                {
                    current_result += next_number;
                }
                else if (operator_token == "-")
                {
                    current_result -= next_number;
                }
                else if (operator_token == "*")
                {
                    current_result *= next_number;
                }
                else if (operator_token == "/")
                {
                    if (ErrorHandler.IsSafeToDivide(next_number))
                    {
                        current_result /= next_number;
                    }
                    else
                    {
                        Console.WriteLine("Error: Cannot divide by zero.");
                        return 0;
                    }


                }

                index += 2;
            }

            return current_result;
        }

        Console.WriteLine("Error: Invalid token sequence.");
        return 0;
    }
}