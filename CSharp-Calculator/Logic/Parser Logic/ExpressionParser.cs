namespace CSharp_Calculator.Logic;

public class ExpressionParser
{
    public static void Parser(string expression)
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
                
                Console.Write($"Found Number:{CurrentNumber} \n ");
                Console.WriteLine($"Found operator:{Current_Char}");
                list.Add(CurrentNumber);
                list.Add(Current_Char.ToString());
                CurrentNumber = "";
            }
            else
            {
                Console.WriteLine($"Unknown character: {Current_Char}");
            }
        }
        
        Console.WriteLine($"Found Number:{CurrentNumber} \n ");
        list.Add(CurrentNumber);
      /*  
        Console.WriteLine("\n ");
        for (int i = 0; i < list.Count; i++)
        {
            Console.WriteLine(list[i]);
        }
        */
    }
}