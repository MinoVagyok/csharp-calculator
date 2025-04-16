using System;
using CSharp_Calculator.Logic;


class Program
{
    
    static void Main(string[] args)
    {
        Dictionary<int, Action> Menu = new Dictionary<int, Action>()
        {
            { 1, MultiInputOperations.MultiInPutSum },
            { 3, MultiInputOperations.MultiInPutTimes },
            { 4, ActionOperations.Div }
            
        };
        bool flag = true;
        while (flag)
        {
            Console.WriteLine("*** Calculator ***");
            Console.WriteLine("0 - Exit");
            Console.WriteLine("1 - Basic operations (sum, subtract)");
            Console.WriteLine("3 - times");
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

        }
    }

}

