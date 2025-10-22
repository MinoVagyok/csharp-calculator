namespace CSharp_Calculator.Logic.UI_Logic;
using MatrixLibrary;

public class Menu
{
    public static void EvaluateExpression()
    {
        Console.WriteLine("Enter expression:");
        var input = Console.ReadLine();
        try
        {
            List<Token_Logic.Token> list = ExpressionTokenizer.Tokenizer(input);
            var postfix = ShuntingYard.ConvertToPostFix(list);
            var result = ExpressionEvaluator.EvaluatePostFix(postfix);
            Console.WriteLine($"Result:  {result} ");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}" );
        }
    }

    public static void LoadMatrixToDictionary(Dictionary<string, Matrix> matrices)
    {
        Console.WriteLine("Enter your filename (e.g. matrix1.json or matrix2.txt):");
        string filename = Console.ReadLine();
        if (!File.Exists(filename))
        {
            Console.WriteLine("Error: File does not exist: " + filename);
            return;
        }
        
        Console.WriteLine("Give a name to this matrix (e.g. A, B, input 1, filtered):");
        string matrixName = Console.ReadLine();

        Matrix matrix = null;
        try
        {
            if (filename.EndsWith(".json"))
            {
                matrix = MatrixFileReader.LoadFromJson(filename);
            }
            else if (filename.EndsWith(".txt"))
            {
                matrix = MatrixFileReader.LoadFromTxt(filename);
            }
            else
            {
                Console.WriteLine("Error: Not supported file format (e.g. matrix1.json or matrix2.txt):");
                return;
            }

            if (matrix != null)
            {
                matrices[matrixName] = matrix;
                Console.WriteLine($"Matrix '{matrixName}' loaded successfully.");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while loading matrix: {ex.Message}");
            
        }
    }

    public static void ListMatrixNames(Dictionary<string, Matrix> matrices)
    { 
      if (matrices.Count == 0)
      {
          Console.WriteLine("No matrices loaded.");
          return;
      }

      Console.WriteLine("Loaded matrices:");
      foreach (var key in matrices.Keys)
      {
          var matrix =  matrices[key];
          Console.WriteLine($" - {key}: ({matrix.Rows} x {matrix.Columns}) \n ");
      }
    }

    public static void DisplayMatrix(Dictionary<string, Matrix> matrices)
    {
        Console.WriteLine("Enter a matrix name to display:");
        string  matrixName = Console.ReadLine();
        if (!matrices.ContainsKey(matrixName))
        {
            Console.WriteLine($"Matrix '{matrixName}' not found");
            return;
        }
        MatrixOperations.PrintMatrix(matrices[matrixName]);
    }
    public static void AddTwoMatrices(Dictionary<string, Matrix> matrices)
    {
        Console.Write("Enter name of Matrix A: ");
        string nameA = Console.ReadLine();

        Console.Write("Enter name of Matrix B: ");
        string nameB = Console.ReadLine();

        if (!matrices.TryGetValue(nameA, out Matrix A) || !matrices.TryGetValue(nameB, out Matrix B))
        {
            Console.WriteLine("One or both matrix names not found.");
            return;
        }

        try
        {
            Matrix result = MatrixOperations.Add(A, B);
            Console.WriteLine("Result of A + B:");
            MatrixOperations.PrintMatrix(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public static void MultiplyTwoMatrices(Dictionary<string, Matrix> matrices)
    {
        Console.Write("Enter name of Matrix A (left): ");
        string nameA = Console.ReadLine();

        Console.Write("Enter name of Matrix B (right): ");
        string nameB = Console.ReadLine();

        if (!matrices.TryGetValue(nameA, out Matrix A) || !matrices.TryGetValue(nameB, out Matrix B))
        {
            Console.WriteLine("One or both matrix names not found.");
            return;
        }

        try
        {
            Matrix result = MatrixOperations.Multiply(A, B);
            Console.WriteLine("Result of A * B:");
            MatrixOperations.PrintMatrix(result);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    public static void TransposeMatrix(Dictionary<string, Matrix> matrices)
    {
        Console.Write("Enter name of matrix to transpose: ");
        string name = Console.ReadLine();

        if (!matrices.TryGetValue(name, out Matrix M))
        {
            Console.WriteLine("Matrix not found.");
            return;
        }

        Matrix result = MatrixOperations.Transpose(M);
        Console.WriteLine("Transposed matrix:");
        MatrixOperations.PrintMatrix(result);
    }
    
}