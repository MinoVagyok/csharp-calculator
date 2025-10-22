using System;
using CSharp_Calculator.Logic;
using CSharp_Calculator.Logic.Error_Handling;
using CSharp_Calculator.Logic.UI_Logic;
using MatrixLibrary;


class Program
{ 
    static void WriteOut(List<Token_Logic.Token> tokens)
    {
        List<string> outputStrings = new List<string>();
        foreach (var token in tokens)
        {
            outputStrings.Add(token.Value);
        }
        
        string joined = string.Join(", ", outputStrings);
        Console.WriteLine($"[{joined}]");
    }

    
    static void Main(string[] args)
   
    {
        /*
       Matrix A = MatrixFileReader.LoadFromJson("matrix.json");
       if (A != null)
       {
           Console.WriteLine($"Matrix 'A' loaded with size: {A.Rows} x {A.Columns}");
           MatrixOperations.PrintMatrix(A);
       }

       Matrix B = MatrixFileReader.LoadFromTxt("matrix.txt");
       if (B != null)
       {
           Console.WriteLine($"Matrix 'B' loaded with size: {B.Rows} x {B.Columns}");
           MatrixOperations.PrintMatrix(B);
       }

       try
       {
           Matrix C = MatrixOperations.Add(A, B);
           MatrixOperations.PrintMatrix(C);
       }
       catch (InvalidOperationException ex)
       {
           Console.WriteLine(ex.Message);
       }

       Matrix D = null;
       try
       {
           D = MatrixOperations.Multiply(A, B);
           MatrixOperations.PrintMatrix(D);
       }
       catch (InvalidOperationException ex)
       {
           Console.WriteLine(ex);
       }

       try
       {
           Matrix E = MatrixOperations.Transpose(D);
           MatrixOperations.PrintMatrix(E);
       }
       catch (Exception ex)
       {
           Console.WriteLine(ex);
       }
       */
        
        
           bool flag = true;
           Dictionary<string, Matrix> matrices = new();
           
           
           while (flag)
           {
               
           Console.Clear();
           Console.WriteLine("*** Calculator***");
           Console.WriteLine("0. Exit");
           Console.WriteLine("1. Calculate typed in expression:");
           Console.WriteLine("2. Load matrix from file");
           Console.WriteLine("3. List Loaded Matrices");
           Console.WriteLine("4. Display Matrix");
           Console.WriteLine("5. Add two matrices");
           Console.WriteLine("6. Multiply two matrices");
           Console.WriteLine("7. Transpose a Matrix");
   
           
           Console.Write("Choose an option: ");
           string choice = Console.ReadLine();
           switch (choice)
           {
               case "0": flag =  false; break;
               case "1": Menu.EvaluateExpression(); break;
               case "2": Menu.LoadMatrixToDictionary(matrices); break;
               case "3": Menu.ListMatrixNames(matrices); break;
               case "4": Menu.DisplayMatrix(matrices); break;
               case "5": Menu.AddTwoMatrices(matrices); break;
               case "6": Menu.MultiplyTwoMatrices(matrices); break;
               case "7": Menu.TransposeMatrix(matrices); break;
               
               default: Console.WriteLine("Invalid Option"); break;
               
               
           }
           
           Console.WriteLine("Press any key to continue...");
           Console.ReadKey();
           
           }
          

}
    
}

