namespace CSharp_Calculator.Logic;

public class ExpressionEvaluator
{
    public static float Evaluate(List<string> tokens)
    {
        float current_result = float.Parse(tokens[0]);

        int index = 1;
        while (index < tokens.Count)
        {
            string operator_token = tokens[index];
            float next_number = float.Parse(tokens[index + 1]);
            
            if(operator_token == "+")
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
                current_result /= next_number;
            }
        
            index += 2;

        }
        return current_result;
    }
}