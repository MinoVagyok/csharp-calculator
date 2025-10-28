using MatrixLibrary;

public static class MatrixValidator
{
    public static bool AreSameSize(Matrix A, Matrix B) =>
        A is not null && B is not null &&
        A.Rows == B.Rows && A.Columns == B.Columns;
    public static bool CanMultiply(Matrix left, Matrix right) =>
        left is not null && right is not null &&
        left.Columns == right.Rows;
    
    public static bool IsSquare(Matrix M) =>
        M is not null && M.Rows == M.Columns;
    
    public static bool IsSymmetric(Matrix M, float tolerance = 1e-6f)
    {
        if (!IsSquare(M)) return false;

        var T = MatrixOperations.Transpose(M);
        return MatrixOperations.AreEqual(M, T, tolerance);
    }


}

