namespace MatrixLibrary;

public static class MatrixOperations
{
    public static Matrix Add(Matrix A, Matrix B)
    {
        if (!MatrixValidator.AreSameSize(A, B))
        {
            Console.WriteLine("Error: Matrix is not the same size");
            return null;
        }
        
        Matrix solution = new Matrix(A.Rows, A.Columns);
        for (int i = 0; i < A.Rows; i++)
        {
            for (int j = 0; j < A.Columns; j++)
            {
                solution.Data[i][j] = A.Data[i][j] + B.Data[i][j];
            }
        }
        return solution;
    }

    public static Matrix Multiply(Matrix left, Matrix right)
    {
        if (!MatrixValidator.CanMultiply(left, right))
        {
            Console.WriteLine("Error: Matrix cannot be multiplied(Dimensions do not match)");
            return null;
        }
        
        Matrix solution = new Matrix(left.Rows, right.Columns);
        for (int i = 0; i < left.Rows; i++)
        {
            for (int j = 0; j < right.Columns; j++)
            {
                for (int k = 0; k < left.Columns; k++)
                {
                    solution.Data[i][j] += left.Data[i][k] * right.Data[k][j];            
                }
            }

        }
        return solution;
    }

    public static Matrix Transpose(Matrix A)
    {
        //A 3x4 Matrix becomes a 4x3, so we have to switch the original dimensions
        Matrix solution = new Matrix(A.Columns, A.Rows);
        for (int i = 0; i < A.Rows; i++)
        {
            for (int j = 0; j < A.Columns; j++)
            {
                solution.Data[j][i] = A.Data[i][j];
            }
        }
        return solution;
    }

    public static bool AreEqual(Matrix A, Matrix B)
    {
        if (!MatrixValidator.AreSameSize(A, B))
        {
            Console.WriteLine("Error: Matrix is not the same size");
            return false;
        }

        for (int i = 0; i < A.Rows; i++)
        {
            for (int j = 0; j < A.Columns; j++)
            {
                if (A.Data[i][j] != B.Data[i][j])
                    return false;
            }
        }
        return true;
    }
    
    public static void PrintMatrix(Matrix M)
    {
        Console.WriteLine($"Matrix ({M.Rows} x {M.Columns}):");
        for (int i = 0; i < M.Rows; i++)
        {
            Console.Write("| ");
            for (int j = 0; j < M.Columns; j++)
            {
                Console.Write($"{M.Data[i][j],6:0.##} "); // Igazítás és max 2 tizedes
            }
            Console.WriteLine("|");
        }
        Console.WriteLine(); // Üres sor a végén
    }
}