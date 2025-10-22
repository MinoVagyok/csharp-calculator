namespace MatrixLibrary
{
    public class Matrix
    {
        public static bool operator ==(Matrix A, Matrix B)
        {
            if (ReferenceEquals(A, B)) return true;
            if (A is null || B is null) return false;
            return MatrixOperations.AreEqual(A, B);
        }

        public static bool operator !=(Matrix A, Matrix B)
        {
            return !(A == B);
        }
        public override bool Equals(object obj)
        {
            if (obj is Matrix other)
            {
                return MatrixOperations.AreEqual(this, other);
            }
            return false;
        }

        public override int GetHashCode()
        {
            return Rows.GetHashCode() ^ Columns.GetHashCode();
        }
        
        
        public List<List<float>> Data { get; set;}
        public int Rows => Data.Count;
        public int Columns => Data.Count > 0 ? Data[0].Count : 0;

        public Matrix()
        {
            Data = new List<List<float>>();
        }

        public Matrix(int rows, int columns, float initialValue = 0)
        {
            Data = new List<List<float>>();
            for (int i = 0; i < rows; i++)
            {
                List<float> newRow = new List<float>();
                {
                    for (int j = 0; j < columns; j++)
                    {
                        newRow.Add(initialValue);
                    }
                }
                Data.Add(newRow);
            }
        }

        public Matrix(List<List<float>> initialData)
        {
            Data = initialData;
        }

        public override string ToString()
        {
            return string.Join("\n", Data.Select(row => string.Join(" ", row)));
        }
    }
    
}

