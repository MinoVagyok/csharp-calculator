using System;
using CSharp_Calculator.Logic;
using CSharp_Calculator.Logic.Error_Handling;


class Program
{
    
    static void Main(string[] args)
    {
       /*
        Dictionary<int, Action> Menu = new Dictionary<int, Action>()
        {
            { 1, MultiInputOperations.MultiInPutSum },
            { 2, MultiInputOperations.MultiInPutSubtract},
            { 3, MultiInputOperations.MultiInPutTimes },
            { 4, ActionOperations.Div }
            
        };
        */
        bool flag = true;
        while (flag)
        {
            
            

            Console.WriteLine("*** Calculator ***");
            Console.WriteLine("Please enter the expression you want to Calculate!");
            List<string> List = ExpressionTokenizer.Tokenizer(Console.ReadLine());
            Console.WriteLine(ExpressionEvaluator.Evaluate(List));

            /*Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Basic operations (sum, subtract)");
            Console.WriteLine("2 - Subtraction operation from fixed base");
            Console.WriteLine("3 - Multiplication");
            Console.WriteLine("4 - div");
            Console.Write("Your choice: ");
            if (int.TryParse(Console.ReadLine(), out int choice))
            {
                if (choice == 0)
                {
                    ActionOperations.Exit(ref flag);
                }

                else if (Menu.ContainsKey(choice))
                {
                    Menu[choice]();
                }
                else
                {
                    Console.WriteLine("*** Error: Unkown menu option. ***");
                }
            }
            else
            {
                Console.WriteLine("*** Error: Invalid number format. Please enter integers only. *** ");
                ActionOperations.Exit(ref flag);
            }
            */
        }
    }

}

