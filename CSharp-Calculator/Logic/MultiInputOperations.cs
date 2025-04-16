namespace CSharp_Calculator.Logic;

public class MultiInputOperations
{
    public static float Sum()
    {
        List<float> numbers = new List<float>();
        Console.WriteLine("*** Multiple-number SUM *** ");
        Console.WriteLine("Enter numbers by one. Type 'q' to finish: ");
        while (true)
        {
            Console.WriteLine("Enter number: ");
            string input = Console.ReadLine();

            if (input == "q")
            {
                return numbers.Sum();
            }

            if (float.TryParse(input, out float number))
            {
                numbers.Add(number);
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'q' to quit.");
            }
            
        }

    }
    
    public static float Times()
    {
        float multiply = 1;
        Console.WriteLine("*** Multiple-number Float multiplication  *** ");
        Console.WriteLine("Enter numbers by one. Type 'q' to finish: ");
        while (true)
        {
   
            Console.Write("Enter number: ");
            string input = Console.ReadLine();
            if (input == "q")
            {
                return multiply;
            }

            if (float.TryParse(input, out float number))
            {
                multiply *= number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'q' to quit.");
            }
        }
    }
    
    // Wrapper for the MultiInputOperations, so it can be used in the Dictionaries
    public static void MultiInPutSum()
    {
        float result = MultiInputOperations.Sum();
        Console.WriteLine($"Sum of numbers: {result}");
        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    } 
    
    public static void MultiInPutTimes()
    {
        float result = MultiInputOperations.Times();
        Console.WriteLine($"Multiplication: {result}");
        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    } 
}