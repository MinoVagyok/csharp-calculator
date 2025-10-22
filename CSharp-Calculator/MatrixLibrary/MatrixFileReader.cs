

namespace MatrixLibrary;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Globalization;

public static class MatrixFileReader
{


    public static Matrix LoadFromTxt(string inpath)
    {
        if (!File.Exists(inpath))
        {
            Console.WriteLine("File does not exist");
            return null;
        }

        string path = inpath;
        string[] lines = File.ReadAllLines(path);
        List<List<float>> matrixData = new List<List<float>>();
        int? expectedCols = null;
        int lineNo = 0;


        foreach (string rawLine in lines)
        {
            lineNo++;
            string line = rawLine.Trim();

            if (line == "" || line.StartsWith("#"))
                continue;

            var tokens = line.Split(null);

            if (expectedCols == null)
            {
                expectedCols = tokens.Length;
            }

            else if (tokens.Length != expectedCols)
            {
                Console.WriteLine($"Error: inconsistent column count at line {lineNo}");
                return null;
            }

            var row = new List<float>();
            int colNo = 0;

            foreach (string t in tokens)
            {
                colNo++;
                if (!float.TryParse(t, NumberStyles.Any, CultureInfo.InvariantCulture, out float value))
                {
                    Console.WriteLine($"Error: invalid number '{t}' at line {lineNo}, col {colNo}");
                    return null;
                }

                row.Add(value);
            }

            matrixData.Add(row);
        }

        if (matrixData.Count == 0)
        {
            Console.WriteLine("Error: file contains no data rows");
            return null;
        }

        return new Matrix(matrixData);
    }
    public static Matrix LoadFromJson(string path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Error: JSON file does not exist.");
            return null;
        }

        string json = File.ReadAllText(path);
        Matrix matrix = JsonSerializer.Deserialize<Matrix>(json);
        if (matrix == null || matrix.Data == null || matrix.Data.Count == 0 || matrix.Columns == 0)
        {
            Console.WriteLine("Error: JSON file is invalid or contains no usable matrix data.");
            return null;
        }

        return matrix;
    }

}