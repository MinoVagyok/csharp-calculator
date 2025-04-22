namespace CSharp_Calculator.Logic;

public class MultiInputOperations
{
    public static float MultiSum()
    {
        float base_number = 0;
        Console.WriteLine("*** Multiple-number SUM *** ");
        Console.WriteLine("Enter numbers by one. Type 'q' to finish: ");
        while (true)
        {
            Console.WriteLine("Enter number: ");
            string input = Console.ReadLine();

            if (input == "q")
            {
                return base_number;
            }

            if (float.TryParse(input, out float number))
            {
                base_number += number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number or 'q' to quit.");
            }
        }
            
    }
    
    
    public static float MultiSubTract()
    {
        float base_number = 0;
        List<float> numbers = new List<float>();
        Console.WriteLine("*** Multiple-number SUM *** ");
        Console.WriteLine("Enter numbers by one. Type 'q' to finish: ");
        while (true)
        {
            Console.WriteLine("Enter number: ");
            string input = Console.ReadLine();
            if (input == "q")
            {
                break;
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
        float result = numbers[0];
        for (int i = 1; i < numbers.Count; i++)
        {
            result -= numbers[i];
        }
        return result;
    }
    
    public static float MultiTimes()
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
    
    // Wrappers for the MultiInputOperations, so it can be used in the Dictionaries
    public static void MultiInPutSum()
    {
        float result = MultiInputOperations.MultiSum();
        Console.WriteLine($"Sum of numbers: {result}");
        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    } 
    
    public static void MultiInPutTimes()
    {
        float result = MultiInputOperations.MultiTimes();
        Console.WriteLine($"Multiplication: {result}");
        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    }

    public static void MultiInPutSubtract()
    {
        float result = MultiInputOperations.MultiSubTract();
        Console.WriteLine($"Subtraction: {result}");
        Console.WriteLine("Press Enter to return to menu...");
        Console.ReadLine();
    }

}
