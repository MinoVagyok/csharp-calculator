using System;
using CSharp_Calculator.Logic;
using CSharp_Calculator.Logic.Error_Handling;
using CSharp_Calculator.Logic.UI_Logic;
using MatrixLibrary;


class Program
{ 
    static void Main(string[] args)
   
    {
           bool flag = true;
           Dictionary<string, Matrix> matrices = new();
           
           while (flag)
           {
               
           Console.Clear();
           ConsoleUI.Info("*** Calculator***");
           ConsoleUI.Info("0. Exit");
           ConsoleUI.Info("1. Calculate typed in expression:");
           ConsoleUI.Info("2. Load matrix from file");
           ConsoleUI.Info("3. List loaded matrices");
           ConsoleUI.Info("4. Display matrix");
           ConsoleUI.Info("5. Add two matrices");
           ConsoleUI.Info("6. Multiply two matrices");
           ConsoleUI.Info("7. Transpose a matrix");
   
           
           ConsoleUI.Info("Choose an option: ");
           var choice = (Console.ReadLine() ?? "").Trim();
           switch (choice)
           {
               case "0": flag =  false; break;
               case "1": MenuRunner.Run(Menu.EvaluateExpression); break;
               case "2": MenuRunner.Run(() => Menu.LoadMatrixToDictionary(matrices)); break;
               case "3": MenuRunner.Run(() => Menu.ListMatrixNames(matrices)); break;
               case "4": MenuRunner.Run(() => Menu.DisplayMatrix(matrices)); break;
               case "5": MenuRunner.Run(() => Menu.AddTwoMatrices(matrices)); break;
               case "6": MenuRunner.Run(() => Menu.MultiplyTwoMatrices(matrices)); break;
               case "7": MenuRunner.Run(() => Menu.TransposeMatrix(matrices)); break;
               
               default: ConsoleUI.Warn("Invalid Option."); break;
               
               
           }
           if (!flag) break;
           ConsoleUI.Info("Press any key to continue...");
           Console.ReadKey();
           
           }
          

    }
    
}

