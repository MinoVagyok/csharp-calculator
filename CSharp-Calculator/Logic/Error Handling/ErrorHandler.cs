namespace CSharp_Calculator.Logic.Error_Handling;

using Token = CSharp_Calculator.Logic.Token_Logic.Token;
using TokenType = CSharp_Calculator.Logic.Token_Logic.TokenType;

public static class ErrorHandler
{
    public static bool IsValidTokenSequence(List<Token> tokens)
    {
        if (tokens.Count < 3) return false;

        for (int i = 0; i < tokens.Count; i++)
        {
            var token = tokens[i];

            if (i % 2 == 0) // Every even index should be a number
            {
                if (token.Type != TokenType.Number)
                    return false;
            }
            else // Every odd index should be an operator
            {
                if (token.Type != TokenType.Operator)
                    return false;
            }
            //Last token should be a number
            if (tokens[^1].Type != TokenType.Number)
                return false;
        }
        return true;
    }
    
    public static bool IsSafeToDivide(float number)
    {
        return number != 0;
    }

}

