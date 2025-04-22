namespace CSharp_Calculator.Logic;

public static class ActionOperations
{
    
    public static void Exit(ref bool flag)
    {
        Console.WriteLine("Exiting...");
        flag = false;
    }
    
    public static void Div()
    {
        bool validinput = false;
        while (!validinput)
        {
            try
            {

                Console.WriteLine("First number");
                int a = Convert.ToInt32(Console.ReadLine());
        
                Console.WriteLine("Second number");
                int b = Convert.ToInt32(Console.ReadLine());
        
                Console.WriteLine($"Soltuion:  {a/b}");
                validinput = true;
            }
            catch (FormatException)
            {
                Console.WriteLine("*** Error: Invalid number format. Please enter integers only. *** ");
            }
        }
        
    }

    

    
}