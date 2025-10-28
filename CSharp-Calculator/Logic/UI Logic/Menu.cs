namespace CSharp_Calculator.Logic.UI_Logic;
using MatrixLibrary;
using System.IO; 


public static class Menu
{
    public static void EvaluateExpression()
    {
        ConsoleUI.Info("Enter expression:");
        var input = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Expression is empty.", nameof(input));
        input = input.Trim();

        List<Token_Logic.Token> list = ExpressionTokenizer.Tokenizer(input);
            var postfix = ShuntingYard.ConvertToPostFix(list);
            var result = ExpressionEvaluator.EvaluatePostFix(postfix);
            ConsoleUI.Success($"Result: {result}");
    }
    
    public static void LoadMatrixToDictionary(Dictionary<string, Matrix> matrices)
    {
        ConsoleUI.Info("Enter your filename (e.g. matrix1.json or matrix2.txt):");
        string filename = (Console.ReadLine() ?? "").Trim();

        if (!File.Exists(filename))
            throw new FileNotFoundException("File does not exist: " + filename, filename);

        ConsoleUI.Info("Give a name to this matrix (e.g. A, B, input 1, filtered):");
        string matrixName = (Console.ReadLine() ?? "").Trim();
        
        if (string.IsNullOrWhiteSpace(matrixName))
            throw new  ArgumentException("Matrix name is empty.", nameof(matrixName));

        Matrix matrix;
        string ext = Path.GetExtension(filename);

        if (ext.Equals(".json", StringComparison.OrdinalIgnoreCase))
        {
            matrix = MatrixFileReader.LoadFromJson(filename);
        }
        else if (ext.Equals(".txt", StringComparison.OrdinalIgnoreCase))
        {
            matrix = MatrixFileReader.LoadFromTxt(filename);
        }
        else
        {
            throw new NotSupportedException("Unsupported file format. Use .json or .txt.");
        }

        matrices[matrixName] = matrix;
        ConsoleUI.Success($"Matrix '{matrixName}' loaded successfully.");
    }

    public static void ListMatrixNames(Dictionary<string, Matrix> matrices)
    { 
      if (matrices.Count == 0)
      {
          ConsoleUI.Warn("No matrices loaded.");
          return;
      }

      ConsoleUI.Info("Loaded matrices:");
      foreach (var kvp in matrices)
      {
          var name = kvp.Key;
          var m = kvp.Value;
          ConsoleUI.Success($" - {name}: ({m.Rows} x {m.Columns})");
      }
    }

    public static void DisplayMatrix(Dictionary<string, Matrix> matrices)
    {
        ConsoleUI.Info("Enter a matrix name to display:");
        var name = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Matrix name is empty.", nameof(name));
        
        DisplayMatrix_Core(matrices, name);
    }
    private static void DisplayMatrix_Core(Dictionary<string, Matrix> matrices, string name)
    {
        if (!matrices.TryGetValue(name, out var matrix))
            throw new KeyNotFoundException($"Matrix '{name}' not found.");
        ConsoleUI.PrintMatrix(matrix);
    }
    public static void AddTwoMatrices(Dictionary<string, Matrix> matrices)
    {
        ConsoleUI.Info("Enter name of Matrix A: ");
        string nameA = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(nameA))
            throw new ArgumentException("Matrix name is empty.", nameof(nameA));

        ConsoleUI.Info("Enter name of Matrix B: ");
        string nameB = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(nameB))
            throw new ArgumentException("Matrix name is empty.", nameof(nameB));

        if (!matrices.TryGetValue(nameA, out Matrix A) || !matrices.TryGetValue(nameB, out Matrix B))
            throw new KeyNotFoundException($"One or both matrix names not found ('{nameA}', '{nameB}').");
        
        AddTwoMatrices_Core(A, B);
        
    }
    private static void AddTwoMatrices_Core(Matrix A, Matrix B)
    {
        Matrix result = MatrixOperations.Add(A, B);
        ConsoleUI.Success("Result of A + B:");
        ConsoleUI.PrintMatrix(result);
        
    }
    
    public static void MultiplyTwoMatrices(Dictionary<string, Matrix> matrices)
    {
        ConsoleUI.Info("Enter name of Matrix A (left): ");
        string nameA = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(nameA))
            throw new ArgumentException("Matrix name is empty.", nameof(nameA));

        ConsoleUI.Info("Enter name of Matrix B (right): ");
        string nameB = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(nameB))
            throw new ArgumentException("Matrix name is empty.", nameof(nameB));

        if (!matrices.TryGetValue(nameA, out Matrix A) || !matrices.TryGetValue(nameB, out Matrix B))
            throw new KeyNotFoundException($"One or both matrix names not found ('{nameA}', '{nameB}').");
        
        MultiplyTwoMatrices_Core(A, B);
    }
    
    private static void MultiplyTwoMatrices_Core(Matrix A, Matrix B)
    {
        Matrix result = MatrixOperations.Multiply(A, B);
        ConsoleUI.Success("Result of A * B:");
        ConsoleUI.PrintMatrix(result);
    }
    
    public static void TransposeMatrix(Dictionary<string, Matrix> matrices)
    {
        ConsoleUI.Info("Enter name of matrix to transpose: ");
        string name = (Console.ReadLine() ?? "").Trim();
        if (string.IsNullOrWhiteSpace(name))
            throw new ArgumentException("Matrix name is empty.", nameof(name));
        
        if (!matrices.TryGetValue(name, out Matrix matrix))
            throw new KeyNotFoundException($"Matrix '{name}' not found.");

        TransposeMatrix_Core(matrix);
        
    }
    
   private static void TransposeMatrix_Core(Matrix matrix)
    {
        var result = MatrixOperations.Transpose(matrix);
        ConsoleUI.Success("Transposed matrix:");
        ConsoleUI.PrintMatrix(result);
    }
    
}