namespace CSharp_Calculator.Logic;

public class ExpressionTokenizer
{
    public static List<string> Tokenize(string expression)
    {
        List<string> list = new List<string>();
        string CurrentNumber = "";
        for (int i = 0; i < expression.Length; i++)
        {
            char Current_Char = expression[i];
            if (char.IsDigit(Current_Char))
            {
                CurrentNumber += Current_Char.ToString();
 

            }
            else if (Current_Char == '-' || Current_Char == '+' || Current_Char == '*' || Current_Char == '/')
            {
                list.Add(CurrentNumber);
                list.Add(Current_Char.ToString());
                CurrentNumber = "";
            }
        }
        list.Add(CurrentNumber);
        return list;
    }
}