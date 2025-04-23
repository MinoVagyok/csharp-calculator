namespace CSharp_Calculator.Logic.Error_Handling;

public static class ErrorHandler
{
    public static bool IsOperator(char c)
    {
        
        return c == '+' || c == '-' || c == '*' || c == '/';
    }
    public static bool IsValidToken(string token)
    {
        // A valid token is: has a length of 1 (it is joined by everything), is either a number, or an operator
        return float.TryParse(token, out _) || IsOperator(token[0]) && token.Length == 1;
    }
    public static bool IsValidTokenSequence(List<string> tokens)
    {
        //A  simple rule for valid token sequences: doesn't start with an operator, doesn't end with an operator and two operators shouldn't after each other.

        if (tokens.Count < 3) return false;
        for (int i = 0; i < tokens.Count; i++)
        {
            if (i % 2 == 0)
            {
                if (!float.TryParse(tokens[i], out _)) return false;
            }
            else
            {
                // Checks if the i.ths string's first letter is an operator  
                if (!IsOperator(tokens[i][0])) return false;
            }

        }
        return true;
    }
    
    public static bool IsSafeToDivide(float number)
    {
        return number != 0;
    }

}

