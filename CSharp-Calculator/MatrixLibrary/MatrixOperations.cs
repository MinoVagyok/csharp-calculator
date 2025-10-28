namespace MatrixLibrary;
using System;


public static class MatrixOperations
{


    public static Matrix Add(Matrix A, Matrix B)
    {
        if (A is null) throw new ArgumentNullException(nameof(A));
        if (B is null) throw new ArgumentNullException(nameof(B));
        if (A.Rows != B.Rows || A.Columns != B.Columns)
        {
            throw new InvalidOperationException("Matrices must have the same size for addition.");
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
        if (left is null) throw new ArgumentNullException(nameof(left));
        if (right is null) throw new ArgumentNullException(nameof(right));
        if (left.Columns != right.Rows)
        {
            throw new InvalidOperationException("Incompatible dimensions for multiplication.");
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
        if (A is null) throw new ArgumentNullException(nameof(A));
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

    public static bool AreEqual(Matrix A, Matrix B, float tolerance = 1e-6f)
    {
        if (A is null || B is null) return false;
        if (A.Rows != B.Rows || A.Columns != B.Columns) return false;

        if (tolerance <= 0f)
        {
            for (int i = 0; i < A.Rows; i++)
            {
                for (int j = 0; j < A.Columns; j++)
                {
                    if (A.Data[i][j] != B.Data[i][j]) return false;
                }
            }
            return true;
        }

        for (int i = 0; i < A.Rows; i++)
        {
            for (int j = 0; j < A.Columns; j++)
            {
                if (Math.Abs(A.Data[i][j] - B.Data[i][j]) > tolerance) return false;
            }
        }
        return true;
    }
    

}