using MatrixLibrary;

public class MatrixValidator
{
    public static bool AreSameSize(Matrix A, Matrix B) => A.Rows == B.Rows && A.Columns == B.Columns;
    public static bool CanMultiply(Matrix A, Matrix B) => A.Rows == B.Columns;
    
    public static bool IsSquare(Matrix M) => M.Rows == M.Columns;
    
    public static bool IsSymmetric(Matrix M)
    {
        if (!IsSquare(M))
        {
            Console.WriteLine("Error: Matrix is not square, cannot be symmetric.");
            return false;
        }
        return M == MatrixOperations.Transpose(M);
    }

}

