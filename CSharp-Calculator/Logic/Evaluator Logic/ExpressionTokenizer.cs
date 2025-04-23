using System.Runtime.InteropServices.JavaScript;
using CSharp_Calculator.Logic.Error_Handling;

namespace CSharp_Calculator.Logic;

public class ExpressionTokenizer
{
    public static List<string> Tokenizer(string expression)
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
                if ( !string.IsNullOrEmpty(CurrentNumber) && ErrorHandler.IsValidToken(CurrentNumber))
                {
        
                    list.Add(CurrentNumber);
                }
                else
                {
                    Console.WriteLine("Error: This isnt a number");
                }

                if (ErrorHandler.IsValidToken(Current_Char.ToString()))
                {

                    list.Add(Current_Char.ToString());
                }
                else
                {
                    Console.WriteLine("Error: This isnt an operator");
                }
                
                CurrentNumber = "";
            }
        }

        if (!string.IsNullOrEmpty(CurrentNumber) && ErrorHandler.IsValidToken(CurrentNumber))
        {
            list.Add(CurrentNumber);

        }
        else
        {
            Console.WriteLine("Error: This isnt a number");
        }
        return list;
    }
}