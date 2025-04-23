namespace CSharp_Calculator.Logic.Error_Handling;

public static class ErrorHandler
{
    
    public static bool IsOperator(char c)
    {
        return true;
    }

    public static bool IsValidToken(string token)
    {
        return true;
    }

    public static bool IsvalidTokenSequence(List<string> tokens)
    {
        return true;
    }

    public static bool IsSafeToDivide(float number)
    {
        return number != 0;
    }



}

